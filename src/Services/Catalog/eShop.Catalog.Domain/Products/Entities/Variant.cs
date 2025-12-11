using eShop.SharedKernel.Domain.Primitives;
using eShop.SharedKernel.Domain.Results;

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

    public override Result EnsureInvariants()
    {
        throw new NotImplementedException();
    }
    internal void Activate() => IsActive = true;

    //? Activate (Color, Size)
}
