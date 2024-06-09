using System.Text.Json.Serialization;

namespace DigitalLibrary.Modules.Books.Application.Contracts;

public static class PublisherContracts
{
    public class PublisherResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}
