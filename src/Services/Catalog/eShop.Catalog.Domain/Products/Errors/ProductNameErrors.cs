using eShop.SharedKernel.Domain.Errors;

namespace eShop.Catalog.Domain.Products.Errors;

internal static partial class ProductNameErrors
{
    public static class Name
    {
        public static readonly Error Required = Error.Validation("Name.Required", "Name is a required");

        public static Error TooShort(int min) => Error.Validation("Name.TooShort", $"Name must be at least {min} characters");
        public static Error TooLong(int max) => Error.Validation("Name.TooLong", $"Name must be at most {max} characters");

    }
}
