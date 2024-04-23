using System.Text.Json.Serialization;

namespace Core.Entities;

public class Product : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    [JsonPropertyName("image")]
    public string PictureUrl { get; set; }
    public ProductCategory ProductCategory { get; set; }
    [JsonPropertyName("category_id")]
    public int ProductCategoryId { get; set; }
    public ProductRating ProductRating { get; set; }
}