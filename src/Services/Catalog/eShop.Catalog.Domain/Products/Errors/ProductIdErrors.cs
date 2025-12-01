using eShop.SharedKernel.Domain.Errors;

namespace eShop.Catalog.Domain.Products.Errors;

public static partial class ProductErrors
{
    public static class Id
    {
        public static readonly Error Empty = Error.Validation(

            "Product.Id.Empty",
            "Product id cannot be empty"

        );
    }
}
