using eShop.Catalog.Domain.Products.Enums;
using eShop.Catalog.Domain.Products.ValueObjects;
using eShop.SharedKernel.Domain.Primitives;
using eShop.SharedKernel.Domain.Results;

namespace eShop.Catalog.Domain.Products;

public class Product : EntityBase<Guid>
{
    public ProductName Name { get; private set; }
    public decimal Price { get; private set; }
    public ProductCode Code { get; private set; }
    public ProductStatus Status { get; private set; }
    public string? Description { get; set; }

    private Product(Guid id, ProductName name, ProductCode code, decimal price,ProductStatus status, string? description = default)
        : base(id)
    {
        Name = name;
        Code = code;
        Price= price;
        Status = status;
        Description = description;

    }
    public static Result<Product> Create(
        Guid productId,
        string name,
        string code,
        decimal price,
        ProductStatus status,
        string description  
) 
    { 
        var createNameResult = ProductName.Create(name);
        if (createNameResult.IsFailure) 
        {
            return Result.Failure<Product>(createNameResult.Error);
        }

        var createCodeResult = ProductCode.Create(code);
        if (createCodeResult.IsFailure)
        {
            return Result.Failure<Product>(createCodeResult.Error);
        }

        return Result.Success( new Product(productId, createNameResult.Value, createCodeResult.Value, price, ProductStatus.Draft,description));
    }

    public Result UpdateName(string name) 
    { 
        var result=ProductName.Create(name);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        Name= result.Value;
        return Result.Success();
    }

    public Result UpdateCode(string code)
    {
        var result = ProductCode.Create(code);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        Code = result.Value;
        return Result.Success();
    }
}
