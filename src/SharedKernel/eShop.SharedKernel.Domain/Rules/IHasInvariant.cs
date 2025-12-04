using eShop.SharedKernel.Domain.Results;

namespace eShop.SharedKernel.Domain.Rules;

public interface IHasInvariant
{
    Result EnsureInvariants();

}
