using eShop.Catalog.Domain.Products.Entities;
using eShop.SharedKernel.Domain.Errors;
using eShop.SharedKernel.Domain.Rules;

namespace eShop.Catalog.Domain.Products.Rules.Invariants;

public class ActiveProductMustHavePriceRule : ICheckRule<Product>
{
    public Error Error => throw new NotImplementedException();

    public bool IsBroken(Product entity)
    {
        throw new NotImplementedException();
    }
}
