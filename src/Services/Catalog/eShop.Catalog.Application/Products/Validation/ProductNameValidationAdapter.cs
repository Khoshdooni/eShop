using eShop.Catalog.Application.Contracts.Products.Validation;
using eShop.Catalog.Domain.Products.Rules.Validation;
using eShop.SharedKernel.Domain.Results;

namespace eShop.Catalog.Application.Products.Validation;

public class ProductNameValidationAdapter : IProductNameValidationAdapter
{
    public Result Validate(string value) => ProductCodeRules.Validate(value);

}
