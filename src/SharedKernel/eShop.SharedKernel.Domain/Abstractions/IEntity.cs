using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Domain.Abstractions;

public interface IEntity<out TId>
{
    TId Id { get; }
}
