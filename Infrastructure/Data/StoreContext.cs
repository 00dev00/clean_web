using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
{
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductRating> ProductRatings { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}