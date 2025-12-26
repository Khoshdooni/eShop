using eShop.Catalog.Domain.Products.Enums;
using eShop.Catalog.Domain.Products.Errors;
using eShop.Catalog.Domain.Products.Events;
using eShop.Catalog.Domain.Products.Rules.Invariants;
using eShop.Catalog.Domain.Products.ValueObjects;
using eShop.SharedKernel.Domain.Primitives;
using eShop.SharedKernel.Domain.Results;
using eShop.SharedKernel.Domain.Rules;
using eShop.SharedKernel.Domain.ValueObjects;
namespace eShop.Catalog.Domain.Products.Entities;

internal sealed partial class Product : AggregateRoot<ProductId>
{
    public ProductName Name
    {
        get; private set;
    }
    public Money? BasePrice
    {
        get; private set;
    }
    public ProductCode Code
    {
        get; private set;
    }
    public ProductStatus Status
    {
        get; private set;
    }
    public string? message
    {
        get; set;
    }


    private readonly Image _image = new();
    public Image Image => _image;

    private Product(
        ProductId id,
        ProductName name,
        ProductCode code,
        Money? basePrice,
        string? message = default)
        : base(id)
    {
        Name = name;
        Code = code;
        BasePrice = basePrice;
        Status = ProductStatus.Draft;
        message = message;

        RaiseDomainEvent(new ProductCreatedDomainEvent(Id, Name, Code));
    }
    private readonly List<Variant> _variants = new();
    public IReadOnlyCollection<Variant> Variants => _variants.AsReadOnly();
    public static Result<Product> Create(
        Guid productId,
        string name,
        string code,
        decimal? price,
        string? currencyCode,
        ProductStatus status,
        string? message

) => ValidationChain
        .For(productId)
        .Bind(id => ProductId.Create(id))
        .Bind(id => ProductName.Create(name).Map(n => (id, n)))
        .Bind(t => ProductCode.Create(code).Map(c => (t.id, t.n, c)))
        .Bind(t => Money.CreateOptional(price, currencyCode).Map(p => (t.id, t.n, t.c, p)))
        .Map(t => new Product(t.id, t.n, t.c, t.p, message));

    // { 
    //var createNameResult = ProductName.Create(name);
    //if (createNameResult.IsFailure) 
    //{
    //    return Result.Failure<Product>(createNameResult.Error);
    //}

    //var createCodeResult = ProductCode.Create(code);
    //if (createCodeResult.IsFailure)
    //{
    //    return Result.Failure<Product>(createCodeResult.Error);
    //}

    //var priceResult=Money.CreateOptional(price,currencyCode);
    //if (priceResult.IsFailure) { 
    //    return Result.Failure<Product>(priceResult.Error);
    //}

    //var idResult=ProductId.Create(id);
    //if (idResult.IsFailure)
    //{
    //    return Result.Failure<Product>(idResult.Error);
    //}

    //return Result.Success( 
    //    new Product(
    //        idResult.Value, 
    //        createNameResult.Value, 
    //        createCodeResult.Value, 
    //        priceResult.Value, 
    //        ProductStatus.Draft,
    //        message));
    // }

    public Result Activate()
    {
        if (!Status.CanBeActivated)
            return Result.Failure(ProductErrors.InvalidState);
        if (BasePrice is null)
        {
            return Result.Failure(ProductErrors.InvalidState);
        }
        Status = ProductStatus.Active;

        RaiseDomainEvent(new ProductActivatedDomainEvent(Id));
        return Result.Success();
    }


    public Result ChangeName(string name)
    {
        var result = ProductName.Create(name);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        Name = result.Value;
        return Result.Success();
    }

    public Result ChangeCode(string code)
    {
        var result = ProductCode.Create(code);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        Code = result.Value;
        return Result.Success();
    }

    //public override Result EnsureInvariants()
    //{
    //    //چک کردن اینواریانت خودش

    //    //ActiveProductMustHavePriceRule
    //    //ActiveVariantMustHaveColorRule

    //    //چک کردن اینواریانت واریانت ها 

    //    throw new NotImplementedException();
    //}
    public override Result EnsureInvariants() =>
        InvariantChain
        .For(this)
        .Include(new ActiveProductMustHavePriceRule())
        .IncludeNested(_variants.ToArray())
        // .IncludeNested(_image)
        .EnsureValid();


    //public Result AddVariant(Guid id, string name, string color, string size)
    //{
    //    //?Transition(deleted,archived)
    //    //?Business(variantDublicateName)
    //    //?Invariant
    //    var rule = new ActiveProductMustHavePriceRule();
    //    var isBroken = rule.IsBroken(this);
    //    if (isBroken)
    //    {
    //        return Result.Failure(rule.Error);
    //    }

    //    return Result.Success();
    //}
    //public Result AddVariant(Guid id, string name, string color, string size) =>
    //    ValidationChain
    //    .For((id, name, color, size))
    //    .Bind(v => Variant.Create(v.id, v.name, v.color, v.size))
    //    .Bind(





    //         );


}
