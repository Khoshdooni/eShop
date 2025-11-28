using eShop.SharedKernel.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Domain.Results;

public static class ResultExtensions
{
    public static Result<TIn> Ensure<TIn>(
        this Result<TIn> result,
        Func<TIn,bool> predicate,
        Error error       
        )
    {
        if(result.IsFailure) return result;

        var isValid = predicate(result.Value);
        if(isValid) return result;

        return Result<TIn>.Failure(error);
    }






}
