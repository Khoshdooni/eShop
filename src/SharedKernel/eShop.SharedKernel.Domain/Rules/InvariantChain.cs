using eShop.SharedKernel.Domain.Abstractions;

namespace eShop.SharedKernel.Domain.Rules;

public readonly struct InvariantChain
{
    public static InvariantBuilder<T> For<T>(T entity)
        where T : IEntity => new InvariantBuilder<T>(entity);

}
