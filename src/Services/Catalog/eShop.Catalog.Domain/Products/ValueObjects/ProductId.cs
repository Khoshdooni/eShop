using eShop.SharedKernel.Domain.Abstractions;
using eShop.SharedKernel.Domain.Primitives;

namespace eShop.Catalog.Domain.Products.ValueObjects;

public record ProductId(long value):EntityId<long>(value)
{
    //public static ProductId New()=>new ProductId(Guid.NewGuid());   
    public static ProductId New(IIdGenerator<long> generator)=>new ProductId(generator.NewId());   
}
