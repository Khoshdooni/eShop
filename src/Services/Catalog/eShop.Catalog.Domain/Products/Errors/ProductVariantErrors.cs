using eShop.SharedKernel.Domain.Errors;

namespace eShop.Catalog.Domain.Products.Errors;

public static partial class ProductErrors
{
    public static class Variant
    {
        public static readonly Error MustHaveColorWhenActive = Error.Validation(

            "Product.Variant.MustHaveColorWhenActive",
            "When variant is active must have color"

        );
        public static readonly Error MustHaveSizeWhenActive = Error.Validation(

            "Product.Variant.MustHaveSizeWhenActive",
            "When variant is active must have size"

        );
    }

}
