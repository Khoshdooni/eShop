using eShop.Catalog.Domain.Products.Rules;
using eShop.SharedKernel.Domain.Guards;
using eShop.SharedKernel.Domain.Results;
using eShop.SharedKernel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Catalog.Domain.Products.ValueObjects;

public record ProductCode
{
    public string Value { get; }
    public ProductCode(string value) => Value = value;

    //public static Result<ProductCode> Create(string value)
    //{
    //    var validateResult= ProductCodeRules.Validate(value);
    //    if (validateResult.IsFailure)
    //    {
    //        return Result.Failure<ProductCode>(validateResult.Error);
    //    }

    //    return Result.Success(new ProductCode(value));
    //}
    public static Result<ProductCode> Create(string value)=>    
        ValueObjectFactory.Create(value,ProductCodeRules.Validate,v=>new ProductCode(v));
    
}
