using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DigitalLibrary.Common.Domain.Attributes;

namespace DigitalLibrary.Modules.Books.Endpoints.Contracts;

internal sealed class RegisterBookRequest
{
    [Required]
    [MaxLength(320)]
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [JsonPropertyName("publication_date")]
    public DateTime PublicationDate { get; set; }

    [Required]
    [JsonPropertyName("publisher_id")]
    public Guid PublisherId { get; set; }

    [Required]
    [GreaterThanZero]
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    [Required]
    [MaxLength(50)]
    [JsonPropertyName("edition")]
    public string Edition { get; set; } = string.Empty;

    [Required]
    [MaxLength(13)]
    [JsonPropertyName("isbn_10")]
    public string Isbn10 { get; set; } = string.Empty;

    [Required]
    [MaxLength(14)]
    [JsonPropertyName("isbn_13")]
    public string Isbn13 { get; set; } = string.Empty;
}
