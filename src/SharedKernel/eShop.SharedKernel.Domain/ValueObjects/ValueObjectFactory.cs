using eShop.SharedKernel.Domain.Results;

namespace eShop.SharedKernel.Domain.ValueObjects;

public class ValueObjectFactory
{
    protected ValueObjectFactory() { }

    public static Result<TVO> Create<TVO, T>
        (
             T value,
             Func<T, Result<T>> validate,
             Func<T, TVO> creator
    )
    {
        var isvalid=validate( value );
        return isvalid.IsFailure
            ? Result.Failure<TVO>(isvalid.Error)
            :Result.Success(creator(value));

    }
}
