using eShop.SharedKernel.Domain.Abstractions;

namespace eShop.SharedKernel.Domain.Rules;

public interface ITransitionRule<in T> : IRule
    where T : IEntity
{
    bool CanTransition(T entity);
}
