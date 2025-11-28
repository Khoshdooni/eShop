namespace eShop.SharedKernel.Domain.Results;

public readonly struct ValidationChain
{
    public static Result<T> For<T>(T value) => Result.Success(value);

}
