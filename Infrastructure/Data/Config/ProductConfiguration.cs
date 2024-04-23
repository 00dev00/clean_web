using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(8, 2)");
        builder.Property(p => p.PictureUrl).IsRequired();
        builder.HasOne(p => p.ProductCategory).WithMany().HasForeignKey(p => p.ProductCategoryId);
        builder.HasOne(p => p.ProductRating).WithOne();
    }
}

public class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
{
    public void Configure(EntityTypeBuilder<ProductRating> builder)
    {
        builder.Property(pr => pr.Rate).IsRequired();
        builder.Property(pr => pr.Count).IsRequired();
        builder.HasOne<Product>().WithOne(p => p.ProductRating).HasForeignKey((ProductRating p) => p.ProductId);
    }
}
