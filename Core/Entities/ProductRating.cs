using System.Text.Json.Serialization;

namespace Core.Entities;

public class ProductRating : BaseEntity
{
    [JsonPropertyName("rate")]
    public double Rate { get; set; } = 0;
    [JsonPropertyName("count")]
    public int Count { get; set; } = 0;
    [JsonPropertyName("product_id")]
    public int ProductId { get; set; }
}
