using eShop.Catalog.Domain.Products.Entities;
using eShop.Catalog.Infrastructure.Products;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.Infrastructure.Data;

internal class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Catalog");

        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }

    public DbSet<Product> Products => Set<Product>();
}
