using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Catalog.Domain.Products.Errors;

public static partial class Errors
{
    public static class Code
    {
        public static readonly Error Required = Error.Validation("Code.Required", "Code is a required");
        public static Error TooShort(int min) => Error.Validation("Code.TooShort", $"Code must be at least {min} characters");
        public static Error TooLong(int max) => Error.Validation("Code.TooLong", $"Code must be at most {max} characters");
        public static Error Pattern => Error.Validation("Code.Pattern", $"Code Pattern is invalid");

    }
}


