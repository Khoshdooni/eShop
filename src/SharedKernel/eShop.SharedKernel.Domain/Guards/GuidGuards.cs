using eShop.SharedKernel.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Domain.Guards;

public static class GuidGuards
{
    public static bool NotEmpty(this IGuardClause guard, Guid? value) =>
        value is not null && !Guid.Empty.Equals(value);
}
