using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext storeContext)
    {
        if (!storeContext.ProductCategories.Any())
        {
            var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
            var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
            storeContext.ProductCategories.AddRange(categories);

        }

        if (!storeContext.Products.Any())
        {
            var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            storeContext.Products.AddRange(products);
        }

        await SaveChangesAsync(storeContext);

        if (!storeContext.ProductRatings.Any())
        {
            var ratingsData = File.ReadAllText("../Infrastructure/Data/SeedData/ratings.json");
            var ratings = JsonSerializer.Deserialize<List<ProductRating>>(ratingsData);
            storeContext.ProductRatings.AddRange(ratings);
        }

        await SaveChangesAsync(storeContext);
    }

    private static async Task SaveChangesAsync(StoreContext storeContext) 
    {
        if (storeContext.ChangeTracker.HasChanges())
        {
            await storeContext.SaveChangesAsync();
        }
    }
}
