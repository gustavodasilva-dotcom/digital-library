using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DigitalLibrary.Modules.Books.Domain.Enumerations;

namespace DigitalLibrary.Modules.Books.Endpoints.Contracts;

public class AddAuthorToBookRequest
{
    [Required]
    [JsonPropertyName("book_id")]
    public Guid BookId { get; set; }

    [Required]
    [JsonPropertyName("author_id")]
    public Guid AuthorId { get; set; }

    [Required]
    [JsonPropertyName("author_type")]
    public AuthorTypes AuthorType { get; set; }
}
