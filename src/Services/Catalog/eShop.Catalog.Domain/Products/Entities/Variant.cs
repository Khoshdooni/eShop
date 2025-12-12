using eShop.Catalog.Domain.Products.Rules.Invariants;
using eShop.SharedKernel.Domain.Primitives;
using eShop.SharedKernel.Domain.Results;
using eShop.SharedKernel.Domain.Rules;

namespace eShop.Catalog.Domain.Products.Entities;

public class Variant : EntityBase<Guid>
{
    public string Name { get; private set; }
    public string? Color { get; private set; }
    public string? Size { get; private set; }
    public bool IsActive { get; private set; }
    private Variant(Guid id, string name, string color, string size) : base(id)
    {
        Name = name;
        Color = color;
        Size = size;
        IsActive = false;
    }
    internal static Result<Variant> Create(Guid id, string name, string color, string size)
    {
        return Result.Success(new Variant(id, name, color, size));
    }

    public override Result EnsureInvariants() =>
        InvariantChain
        .For(this)
        .Include(new ActiveVariantMustHaveColorRule())
        .Include(new ActiveVariantMustHaveSizeRule())
        .EnsureValid();

    internal void Activate() => IsActive = true;

    //? Activate (Color, Size)
}
