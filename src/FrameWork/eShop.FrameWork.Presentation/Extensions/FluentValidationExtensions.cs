using eShop.SharedKernel.Domain.Results;
using FluentValidation;
using FluentValidation.Results;

namespace eShop.FrameWork.Presentation.Extensions;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptionsConditions<T, TProperty> UseDomainRules<T, TProperty>(
        this IRuleBuilder<T, TProperty> builder,
        //* Validation Logic
        Func<TProperty, Result> domainRules
    )
    {
        return builder.Custom(
            (value, context) =>
            {
                var result = domainRules(value);
                if (result.IsFailure)
                {
                    context.AddFailure(
                        new ValidationFailure(context.PropertyPath, result.Error.Message)
                    );
                }
            }
        );
    }
}
