using eShop.SharedKernel.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Domain.Guards;

public class Guard:IGuardClause
{
    private Guard() { }

    public static IGuardClause Against { get; set; } = new Guard();
}
