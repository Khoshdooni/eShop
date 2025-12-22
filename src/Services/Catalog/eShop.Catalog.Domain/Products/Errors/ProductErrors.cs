using eShop.SharedKernel.Domain.Errors;

namespace eShop.Catalog.Domain.Products.Errors;

internal static partial class ProductErrors
{
    public static Error InvalidState => Error.Validation("Product.InvalidState", $"Invalid state transition");

}
