using eShop.Catalog.Domain.Products.Enums;

namespace eShop.Catalog.Domain.Products.Rules.Transitions;

internal static class ProductStateTransitionMap
{
    private static readonly Dictionary<ProductStatus, ProductStatus[]> allowedTransitions = new()
    {
        [ProductStatus.Draft] = new[] { ProductStatus.Active, ProductStatus.Deleted },
        [ProductStatus.Active] = new[] { ProductStatus.Inactive, ProductStatus.Deleted },
        [ProductStatus.Archived] = Array.Empty<ProductStatus>(),
    };

    public static bool CanTransition(ProductStatus @from, ProductStatus @to) =>
        allowedTransitions.TryGetValue(@from, out var next) && next.Contains(@to);
}
