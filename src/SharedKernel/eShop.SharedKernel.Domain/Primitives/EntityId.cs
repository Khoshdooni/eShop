namespace eShop.SharedKernel.Domain.Primitives;

public abstract record EntityId<T>(T value)
{
    public override string ToString()=> value?.ToString()??string.Empty;

}
