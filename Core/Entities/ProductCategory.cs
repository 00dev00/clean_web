using System.Text.Json.Serialization;

namespace Core.Entities;

public class ProductCategory : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
