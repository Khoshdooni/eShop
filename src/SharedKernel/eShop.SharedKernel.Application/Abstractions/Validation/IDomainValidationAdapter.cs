using eShop.SharedKernel.Domain.Results;

namespace eShop.SharedKernel.Application.Abstractions.Validation;

public interface IDomainValidationAdapter<T>
{
    Result<T> Validate(T Value);
}
