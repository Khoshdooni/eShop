using eShop.Catalog.Domain.Products.Entities;
using eShop.Catalog.Domain.Products.Enums;
using eShop.SharedKernel.Domain.Errors;
using eShop.SharedKernel.Domain.Rules;

namespace eShop.Catalog.Domain.Products.Rules.Business;

internal class ActiveProductMustHaveAtLeastOneVariantRule : ICheckRule<Product>
{
    public Error Error => throw new NotImplementedException();

    public bool IsBroken(Product product) =>

        product.Status == ProductStatus.Active && product.Variants.Any(v => v.IsActive);

}
