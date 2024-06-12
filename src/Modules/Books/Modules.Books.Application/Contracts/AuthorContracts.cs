using System.Text.Json.Serialization;

namespace DigitalLibrary.Modules.Books.Application.Contracts;

public static class AuthorContracts
{
    public class AuthorResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("about")]
        public string About { get; set; } = string.Empty;

        [JsonPropertyName("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}
