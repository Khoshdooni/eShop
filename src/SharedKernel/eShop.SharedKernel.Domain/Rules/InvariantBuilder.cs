using eShop.SharedKernel.Domain.Abstractions;
using eShop.SharedKernel.Domain.Results;

namespace eShop.SharedKernel.Domain.Rules;

public sealed class InvariantBuilder<T>
    where T : IEntity
{
    private readonly T _target;
    private readonly List<ICheckRule<T>> _rules = new();
    public InvariantBuilder(T target) => _target = target;
    public InvariantBuilder<T> Include(ICheckRule<T> rule)
    {
        _rules.Add(rule);
        return this;
    }
    public Result EnsureValid()
    {
        return Result.Success();
    }
}
