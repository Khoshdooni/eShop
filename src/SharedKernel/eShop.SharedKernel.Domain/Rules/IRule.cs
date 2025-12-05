using eShop.SharedKernel.Domain.Errors;

namespace eShop.SharedKernel.Domain.Rules;

public interface IRule
{
    Error Error { get; }
}
