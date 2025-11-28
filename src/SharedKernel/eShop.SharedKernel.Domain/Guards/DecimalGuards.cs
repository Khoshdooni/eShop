using eShop.SharedKernel.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Domain.Guards;

public static class DecimalGuards
{
    public static bool Positive(this IGuardClause guard, decimal? value) =>
        value is not null && value > 0;

    public static bool NotNegative(this IGuardClause guard, decimal? value) => value >= 0;

    public static bool Max(this IGuardClause guard, decimal? value, decimal max) => value <= max;

    public static bool Min(this IGuardClause guard, decimal? value, decimal min) => value >= min;

    public static bool Between(this IGuardClause guard, decimal value, decimal min, decimal max) =>
        value >= min || value <= max;
}

