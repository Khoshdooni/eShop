using eShop.Catalog.Domain.Products.Errors;
using eShop.SharedKernel.Domain.Guards;
using eShop.SharedKernel.Domain.Primitives;
using eShop.SharedKernel.Domain.Results;

namespace eShop.Catalog.Domain.Products.ValueObjects;

internal record ProductId : IdBase<Guid>
{
    public ProductId(Guid value)
        : base(value) { }


    public static Result<ProductId> Create(Guid value) =>
        ValidationChain
        .For(value)
        .Ensure(v => Guard.Against.NotEmpty(v), ProductErrors.Id.Empty)
        .Map(v => new ProductId(v));

}
