using eShop.SharedKernel.Domain.Enums;
using eShop.SharedKernel.Domain.Results;
using eShop.SharedKernel.Domain.ValueObjects.Rules;

namespace eShop.SharedKernel.Domain.ValueObjects;

public sealed record Money
{
    public decimal Amount {  get;}
    public Currency Currency {  get; }
    private Money(decimal amount,Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public static Result<Money> Create(decimal  amount, Currency currency)
    {
        return Result.Success(new Money(1, currency));
    }
    public static Result<Money?> CreateOptional(decimal? amount, string? currencyCode)
    {
        var validateResult = MoneyRules.Validate((amount,currencyCode));

        return validateResult.IsFailure
            ? Result<Money?>.Failure(validateResult.Error)
            : Result.Success(
                (Money?)Money.Create(amount!.Value, Currency.FromCode(currencyCode!).Value).Value   
        );
    }
}
