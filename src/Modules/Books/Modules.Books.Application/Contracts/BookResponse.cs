using System.Text.Json.Serialization;

namespace DigitalLibrary.Modules.Books.Application.Contracts;

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

    [JsonPropertyName("isbn_10")]
    public string Isbn10 { get; set; } = string.Empty;

    [JsonPropertyName("isbn_13")]
    public string Isbn13 { get; set; } = string.Empty;

    [JsonPropertyName("is_available")]
    public bool IsAvailable { get; set; }

    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; }
}
