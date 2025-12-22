using eShop.SharedKernel.Domain.Primitives;

namespace eShop.Catalog.Domain.Products.Enums;

internal sealed class ProductStatus : Enumeration<ProductStatus>
{
    public static readonly ProductStatus Draft = new(1, "DRAFT", nameof(Draft));
    public static readonly ProductStatus Active = new(2, "ACTIVE", nameof(Active));
    public static readonly ProductStatus Inactive = new(3, "INACTIVE", nameof(Inactive));
    public static readonly ProductStatus Deleted = new(4, "DELETED", nameof(Deleted));
    public static readonly ProductStatus Archived = new(5, "ARCHIVED", nameof(Archived));


    public ProductStatus(int id, string code, string name)
        : base(id, code, name)
    {
    }

    public bool CanBeActivated => this == Draft || this == Inactive;
    public bool CanBeInactivated => this == Active;
    public bool CanBeDeleted => this != Archived;
    public bool CanBeArchived => this == Deleted;

}
