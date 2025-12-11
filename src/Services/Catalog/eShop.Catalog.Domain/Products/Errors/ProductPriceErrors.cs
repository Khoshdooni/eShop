using eShop.SharedKernel.Domain.Errors;

namespace eShop.Catalog.Domain.Products.Errors;


public static partial class ProductErrors
{
    public static class Price
    {
        public static readonly Error ActiveProductMustHavePrice = Error.Validation(

            "Product.Price.ActiveProductMustHavePrice",
            "When product is active must have price"

        );
    }
}
