using eShop.SharedKernel.Domain.Abstractions;

namespace eShop.SharedKernel.Domain.Primitives;

public class AggregateRoot<TId> : EntityBase<TId>, IAggregateRoot
    where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    public AggregateRoot(TId id) : base(id)
    {

    }

    protected void RaiseDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);
    protected void ClearDomainEvent() => _domainEvents.Clear();
}
