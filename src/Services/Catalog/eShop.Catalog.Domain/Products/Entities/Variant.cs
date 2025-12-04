using eShop.SharedKernel.Domain.Primitives;
using eShop.SharedKernel.Domain.Results;

namespace eShop.Catalog.Domain.Products.Entities;

public class Variant : EntityBase<Guid>
{
    public string Name { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }

    public Variant(Guid variantId)
        : base(variantId) { }

    public override Result EnsureInvariants()
    {
        throw new NotImplementedException();
    }

    //? Activate (Color, Size)
}
