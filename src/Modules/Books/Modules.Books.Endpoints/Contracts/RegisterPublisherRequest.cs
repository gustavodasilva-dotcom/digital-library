using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalLibrary.Modules.Books.Endpoints.Contracts;

internal sealed class RegisterPublisherRequest
{
    [Required]
    [MaxLength(200)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
