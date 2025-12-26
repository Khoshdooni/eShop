using eShop.Catalog.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Catalog.Infrastructure.Products;
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).ValueGeneratedNever();

        builder.Property(m => m.Name).IsRequired().IsUnicode().HasMaxLength(100);

        builder.Property(m => m.BasePrice).IsRequired().HasPrecision(10, 3);

        builder.Property(m => m.message).IsRequired(false).IsUnicode().HasMaxLength(250);
    }
}
