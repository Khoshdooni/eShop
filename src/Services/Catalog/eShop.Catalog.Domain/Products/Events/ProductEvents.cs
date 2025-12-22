using eShop.Catalog.Domain.Products.ValueObjects;
using eShop.SharedKernel.Domain.Abstractions;

namespace eShop.Catalog.Domain.Products.Events;

internal sealed record ProductCreatedDomainEvent(
    ProductId prooductId,
    ProductName name,
    ProductCode code
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}

internal sealed record ProductActivatedDomainEvent(
    ProductId prooductId
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
