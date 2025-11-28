using eShop.SharedKernel.Domain.Abstractions;
using eShop.SharedKernel.Domain.Enums;
using eShop.SharedKernel.Domain.Guards;
using eShop.SharedKernel.Domain.Results;
using eShop.SharedKernel.Domain.ValueObjects.Errors;

namespace eShop.SharedKernel.Domain.ValueObjects.Rules;

public sealed class MoneyRules : IValueObjectRules<(decimal? amount, string? currencyCode)>
{
    public MoneyRules()
    {

    }

    public static Result<(decimal? amount, string? currencyCode)> Validate((decimal? amount, string? currencyCode) value)
=> ValidationChain.For(value)
        .Ensure(
                v =>
                (v.amount is null && v.currencyCode is null)
                || (v.amount is not null && v.currencyCode is not null),
                MoneyErrors.Invalid
        )
        .Ensure(v => Guard.Against.Positive(v.amount), MoneyErrors.AmountNegative)
        .Ensure(v => Currency.FromCode(v.currencyCode!).IsSuccess, MoneyErrors.CurrencyNotFound);
}
