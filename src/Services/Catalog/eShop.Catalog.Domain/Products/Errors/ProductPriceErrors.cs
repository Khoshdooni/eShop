using eShop.SharedKernel.Domain.Errors;

namespace eShop.Catalog.Domain.Products.Errors;


public static partial class ProductPriceErrors
{
    public static class Price
    {
        public static readonly Error Empty = Error.Validation(

            "Product.Price.Empty",
            "Product Price cannot be zero"

        );
    }
}
