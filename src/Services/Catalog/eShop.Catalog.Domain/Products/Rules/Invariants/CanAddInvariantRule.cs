using eShop.Catalog.Domain.Products.Entities;
using eShop.Catalog.Domain.Products.Enums;
using eShop.SharedKernel.Domain.Errors;
using eShop.SharedKernel.Domain.Rules;

namespace eShop.Catalog.Domain.Products.Rules.Invariants;

internal class CanAddInvariantRule : ITransitionRule<Product>
{
    public Error Error => throw new NotImplementedException();

    public bool CanTransition(Product product) =>
        product.Status != ProductStatus.Deleted && product.Status != ProductStatus.Archived;

}
