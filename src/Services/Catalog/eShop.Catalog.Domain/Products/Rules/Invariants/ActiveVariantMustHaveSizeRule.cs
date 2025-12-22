using eShop.Catalog.Domain.Products.Entities;
using eShop.Catalog.Domain.Products.Errors;
using eShop.SharedKernel.Domain.Errors;
using eShop.SharedKernel.Domain.Rules;

namespace eShop.Catalog.Domain.Products.Rules.Invariants;

internal class ActiveVariantMustHaveSizeRule : ICheckRule<Variant>
{
    public Error Error => ProductErrors.Variant.MustHaveSizeWhenActive;
    public bool IsBroken(Variant variant) =>
        variant.IsActive && string.IsNullOrEmpty(variant.Size);
}
