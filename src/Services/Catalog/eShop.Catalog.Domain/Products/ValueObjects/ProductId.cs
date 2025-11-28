using eShop.SharedKernel.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Catalog.Domain.Products.ValueObjects;

public record ProductId(Guid value):EntityId<Guid>(value)
{
}
