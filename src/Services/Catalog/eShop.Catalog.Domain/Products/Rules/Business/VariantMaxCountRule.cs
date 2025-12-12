using eShop.Catalog.Domain.Products.Entities;
using eShop.SharedKernel.Domain.Errors;
using eShop.SharedKernel.Domain.Rules;

namespace eShop.Catalog.Domain.Products.Rules.Business;

public class VariantMaxCountRule : ICheckRule<Product>
{
    private const int MAX_COUNT = 30;
    public Error Error => throw new NotImplementedException();

    public bool IsBroken(Product product) =>

        product.Variants.Count(v => v.IsActive) <= MAX_COUNT;

}
