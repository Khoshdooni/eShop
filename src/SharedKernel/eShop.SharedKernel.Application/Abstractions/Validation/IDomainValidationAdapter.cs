using eShop.SharedKernel.Domain.Results;

namespace eShop.SharedKernel.Application.Abstractions.Validation;

public interface IDomainValidationAdapter<in T>
{
    Result Validate(T Value);
}
