using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlingTree.Models
{
    public class Item
    {

        [JsonPropertyName("ID")]
        public int ID { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; } = "";

        [JsonPropertyName("Name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("Description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("Image")]
        public string[]? Image { get; set; }

        [JsonPropertyName("Price")]
        public string Price { get; set; } = "";

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
