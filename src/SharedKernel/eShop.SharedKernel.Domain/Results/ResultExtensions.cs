using eShop.SharedKernel.Domain.Errors;

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

    public static Result<TOut> Map<TIn,TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> map)=>
    
         result.IsSuccess
            ?Result<TOut>.Success(map(result.Value))
            :Result<TOut>.Failure(result.Error);
   

    public static Result<TOut> Bind<TIn, TOut>(
    this Result<TIn> result,
    Func<TIn, Result<TOut>> next)=>
    
         result.IsSuccess
            ? next(result.Value)
            : Result<TOut>.Failure(result.Error);
   
}
