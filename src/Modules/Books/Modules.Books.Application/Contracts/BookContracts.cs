using System.Text.Json.Serialization;
using DigitalLibrary.Modules.Books.Domain.Enumerations;

namespace DigitalLibrary.Modules.Books.Application.Contracts;

public static class BookContracts
{
    public class AuthorResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("author_type")]
        public AuthorTypes Type { get; set; }
    }

    public class PublisherResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class BookResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("publication_date")]
        public DateTime PublicationDate { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("edition")]
        public string Edition { get; set; } = string.Empty;

        [JsonPropertyName("isbn_10")]
        public string Isbn10 { get; set; } = string.Empty;

        [JsonPropertyName("isbn_13")]
        public string Isbn13 { get; set; } = string.Empty;

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; set; }

        [JsonPropertyName("authors")]
        public List<AuthorResponse> Authors { get; set; } = [];

        [JsonPropertyName("publisher")]
        public PublisherResponse Publisher { get; set; } = new();

        [JsonPropertyName("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}
