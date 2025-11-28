using eShop.Catalog.Domain.Products.Errors;
using eShop.SharedKernel.Domain;
using eShop.SharedKernel.Domain.Guards;
using eShop.SharedKernel.Domain.Results;
using System.Text.RegularExpressions;

namespace eShop.Catalog.Domain.Products.Rules;

public class ProductCodeRules
{
    private const int CodeLength = 10;

    private static readonly Regex CodePattern = new(
    @"^[A-Za-z0-9_-]+$",
    RegexOptions.Compiled | RegexOptions.CultureInvariant
);

    //public static Result<string> Validate(string code)
    //{
    //    //var nameEmptyGuard = Guard.Against.NotNullOrEmpty(code, $"Code is Required");
    //    //if (nameEmptyGuard.IsFailure)
    //    //    return Result.Failure<string>(Error.Problem($"ProductCodeRules.Validate.{nameEmptyGuard.Error.Code}", nameEmptyGuard.Error.Description));

    //    //var nameLengthGuard = Guard.Against.Length(code, 3, 30, $"Code  should be in range");
    //    //if (nameLengthGuard.IsFailure)

    //    //    return Result.Failure<string>(Error.Problem($"ProductCodeRules.Validate.{nameLengthGuard.Error.Code}", nameLengthGuard.Error.Description));

    //    return code.ToResult().Ensure(c => string.IsNullOrEmpty(c), Errors.Errors.Code.Required);  


    //}

    //public static Result<string> Validate(string code)=>
    //     code.ToResult().Ensure(c => string.IsNullOrEmpty(c), Errors.Errors.Code.Required);

    //public static Result<string> Validate(string code) =>
    // code.ToResult()
    //     .Ensure(Guard.Against.NotEmpty, Errors.Errors.Code.Required)
    //     .Ensure(c => Guard.Against.Length(c, CodeLength), Errors.Errors.Code.Required)
    //     .Ensure(c => Guard.Against.Pattern(c, CodePattern), Errors.Errors.Code.Pattern);

    public static Result<string> Validate(string code) =>
      ValidationChain.For(code)
     .Ensure(Guard.Against.NotEmpty, Errors.Errors.Code.Required)
     .Ensure(c => Guard.Against.Length(c, CodeLength), Errors.Errors.Code.Required)
     .Ensure(c => Guard.Against.Pattern(c, CodePattern), Errors.Errors.Code.Pattern);

}
