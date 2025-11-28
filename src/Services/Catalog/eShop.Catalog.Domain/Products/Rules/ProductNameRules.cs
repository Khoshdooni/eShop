using eShop.Catalog.Domain.Products.ValueObjects;
using eShop.SharedKernel.Domain;
using eShop.SharedKernel.Domain.Guards;
using eShop.SharedKernel.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Catalog.Domain.Products.Rules;

public class ProductNameRules
{

    //public static Result<string> Validate(string name)
    //{
    private const int Max = 30;
    private const int Min = 3;


    //var nameEmptyGuard = Guard.Against.NotNullOrEmpty(name, $"Name is Required");
    //if (nameEmptyGuard.IsFailure)
    //    return Result.Failure<string>(Errors.Errors.Name.Required);

    //var nameLengthGuard = Guard.Against.MinLength(name, 3, $"Name should be in range");
    //if (nameLengthGuard.IsFailure)

    //    return Result.Failure<string>(Errors.Errors.Name.TooShort(3));
    public static Result<string> Validate(string name) =>
        ValidationChain.For(name)
        .Ensure(Guard.Against.NotEmpty, Errors.Errors.Name.Required)
        .Ensure(c => Guard.Against.MinLength(c, Min), Errors.Errors.Name.TooShort(Min))
        .Ensure(c => Guard.Against.MaxLength(c, Max), Errors.Errors.Name.TooLong(Max));

    }



