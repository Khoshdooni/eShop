using eShop.Catalog.Domain.Products.Rules.Validation;
using eShop.SharedKernel.Domain.Results;
using eShop.SharedKernel.Domain.ValueObjects;

namespace eShop.Catalog.Domain.Products.ValueObjects;

public record ProductName
{
    public string Value { get; }
    public ProductName(string value) => Value = value;

    public static Result<ProductName> Create(string value) =>
        ValueObjectFactory.Create(value, ProductNameRules.Validate, v => new ProductName(v));

    //public static Result<ProductName> Create(string value)
    //{
    //    var validateResult = ProductNameRules.Validate(value);
    //    if (validateResult.IsFailure)
    //    {
    //        return Result.Failure<ProductName>(validateResult.Error);
    //    }

    //    return Result.Success(new ProductName(value));
    //}
}
