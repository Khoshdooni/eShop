using eShop.SharedKernel.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Catalog.Domain.Products.Errors;

public static partial class ProductNameErrors
{
    public static class Name
    {
        public static readonly Error Required = Error.Validation("Name.Required", "Name is a required");

        public static  Error TooShort(int min) => Error.Validation("Name.TooShort", $"Name must be at least {min} characters");
        public static  Error TooLong(int max) => Error.Validation("Name.TooLong", $"Name must be at most {max} characters");

    }
}
