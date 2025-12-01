namespace eShop.SharedKernel.Domain.Abstractions;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }

}
