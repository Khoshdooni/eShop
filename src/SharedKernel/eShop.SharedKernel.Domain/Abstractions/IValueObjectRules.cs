using eShop.SharedKernel.Domain.Results;

namespace eShop.SharedKernel.Domain.Abstractions;

public interface IValueObjectRules<T>
{
   static abstract Result<T> Validate(T value);
}
