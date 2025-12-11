using eShop.Catalog.Domain.Products.Enums;
using eShop.Catalog.Domain.Products.Errors;
using eShop.Catalog.Domain.Products.Events;
using eShop.Catalog.Domain.Products.ValueObjects;
using eShop.SharedKernel.Domain.Primitives;
using eShop.SharedKernel.Domain.Results;
using eShop.SharedKernel.Domain.ValueObjects;
namespace eShop.Catalog.Domain.Products.Entities;

public class Product : AggregateRoot<ProductId>
{
    public ProductName Name { get; private set; }
    public Money? BasePrice { get; private set; }
    public ProductCode Code { get; private set; }
    public ProductStatus Status { get; private set; }
    public string? Description { get; set; }

    private Product(
        ProductId id,
        ProductName name,
        ProductCode code,
        Money? basePrice,
        string? description = default)
        : base(id)
    {
        Name = name;
        Code = code;
        BasePrice = basePrice;
        Status = ProductStatus.Draft;
        Description = description;

        RaiseDomainEvent(new ProductCreatedDomainEvent(Id, Name, Code));
    }
    public static Result<Product> Create(
        Guid productId,
        string name,
        string code,
        decimal? price,
        string? currencyCode,
        ProductStatus status,
        string? description

) => ValidationChain
        .For(productId)
        .Bind(id => ProductId.Create(id))
        .Bind(id => ProductName.Create(name).Map(n => (id, n)))
        .Bind(t => ProductCode.Create(code).Map(c => (t.id, t.n, c)))
        .Bind(t => Money.CreateOptional(price, currencyCode).Map(p => (t.id, t.n, t.c, p)))
        .Map(t => new Product(t.id, t.n, t.c, t.p, description));

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
    //        description));
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

    public override Result EnsureInvariants()
    {
        //چک کردن اینواریانت خودش
        //چک کردن ایواریانت واریانت ها 

        throw new NotImplementedException();
    }

    public void AddVariant()
    {
        //?Transition(deleted,archived)
        //?Business(variantDublicateName)
        //?Invariant
    }
}
