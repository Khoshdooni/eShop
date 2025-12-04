using eShop.SharedKernel.Domain.Abstractions;
using eShop.SharedKernel.Domain.Exceptions;

namespace eShop.SharedKernel.Domain.Primitives;

public abstract class AggregateRoot<TId> : EntityBase<TId>, IAggregateRoot
    where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    public AggregateRoot(TId id) : base(id)
    {

    }

    protected void RaiseDomainEvent(IDomainEvent @event)
    {
        var ensure = EnsureInvariants();
        if (ensure.IsFailure)
        {
            throw new DomainException(ensure.Error);
        }
        _domainEvents.Add(@event);
    }
    protected void ClearDomainEvent() => _domainEvents.Clear();
}
