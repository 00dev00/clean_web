using Core.Entities;
using Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
{
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
}