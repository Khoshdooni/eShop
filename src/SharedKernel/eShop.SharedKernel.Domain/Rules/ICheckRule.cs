using eShop.SharedKernel.Domain.Abstractions;

namespace eShop.SharedKernel.Domain.Rules;

public interface ICheckRule<in T> : IRule
    where T : IEntity
{
    bool IsBroken(T entity);
}
