using eShop.Catalog.Domain.Products.Entities;
using eShop.Catalog.Domain.Products.Enums;
using eShop.Catalog.Domain.Products.Errors;
using eShop.SharedKernel.Domain.Errors;
using eShop.SharedKernel.Domain.Rules;

namespace eShop.Catalog.Domain.Products.Rules.Invariants;

public class ActiveProductMustHavePriceRule : ICheckRule<Product>
{
    public Error Error => ProductErrors.Price.ActiveProductMustHavePrice;

    public bool IsBroken(Product product) =>

         product.Status == ProductStatus.Active && product?.BasePrice is not null;

}
