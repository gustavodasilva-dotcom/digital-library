using System.Text.Json.Serialization;
using DigitalLibrary.Modules.Books.Domain.Enumerations;

namespace DigitalLibrary.Modules.Books.Application.Contracts;

public class BookAuthorResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("author_id")]
    public Guid AuthorId { get; set; }

    [JsonPropertyName("author_type")]
    public AuthorTypes AuthorType { get; set; }
}
