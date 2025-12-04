using eShop.Catalog.Domain.Products.ValueObjects;
using eShop.SharedKernel.Domain.Abstractions;

namespace eShop.Catalog.Domain.Products.Events;

public sealed record ProductCreatedDomainEvent(
    ProductId prooductId,
    ProductName name,
    ProductCode code
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}

public sealed record ProductActivatedDomainEvent(
    ProductId prooductId
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
