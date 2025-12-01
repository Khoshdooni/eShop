using eShop.Catalog.Domain.Products.Enums;

namespace eShop.Catalog.Domain.Products.Rules.Transitions;

public static class ProductStateTransitionMap
{
    private static readonly Dictionary<ProductStatus, ProductStatus[]> allowedTransitions = new()
    {
        [ProductStatus.Draft] = new[] { ProductStatus.Active, ProductStatus.Deleted },
        [ProductStatus.Active] = new[] { ProductStatus.Inactive, ProductStatus.Deleted },
    };

    public static bool CanTransition(ProductStatus @from, ProductStatus @to) => true;
}
