using System.Text.Json.Serialization;

namespace BlazorApp.Shared
{
    public class Link
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
