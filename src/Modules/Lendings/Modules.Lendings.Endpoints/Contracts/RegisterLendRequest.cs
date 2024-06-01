using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalLibrary.Modules.Lendings.Endpoints.Contracts;

public class RegisterLendRequest
{
    [Required]
    [JsonPropertyName("book_id")]
    public Guid BookId { get; set; }

    [Required]
    [JsonPropertyName("start_date")]
    public DateTime StartDate { get; set; }

    [Required]
    [JsonPropertyName("end_date")]
    public DateTime EndDate { get; set; }
}
