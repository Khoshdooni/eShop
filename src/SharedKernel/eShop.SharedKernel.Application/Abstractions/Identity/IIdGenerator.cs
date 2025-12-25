namespace eShop.SharedKernel.Application.Abstractions.Identity;

public interface IIdGenerator<out TId>
{
    TId NewId();
}

