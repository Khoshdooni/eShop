namespace eShop.SharedKernel.Domain.Primitives;

public abstract record IdBase<T>(T value)
{
    public override string ToString()=> value?.ToString()??string.Empty; 

}
