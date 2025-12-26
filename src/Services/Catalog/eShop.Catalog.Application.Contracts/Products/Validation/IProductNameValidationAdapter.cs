using eShop.SharedKernel.Application.Abstractions.Validation;

namespace eShop.Catalog.Application.Contracts.Products.Validation;

public interface IProductNameValidationAdapter : IDomainValidationAdapter<string>
{
}
