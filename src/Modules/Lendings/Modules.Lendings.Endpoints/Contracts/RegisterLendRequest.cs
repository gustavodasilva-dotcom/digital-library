using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DigitalLibrary.Common.Domain.Attributes;

namespace DigitalLibrary.Modules.Lendings.Endpoints.Contracts;

public class RegisterLendRequest
{
    [Required]
    [NotEmptyGuid]
    [JsonPropertyName("book_id")]
    public Guid BookId { get; set; }

    [Required]
    [NotEmptyGuid]
    [JsonPropertyName("patron_id")]
    public Guid PatronId { get; set; }

    [Required]
    [JsonPropertyName("start_date")]
    public DateTime StartDate { get; set; }

    [Required]
    [JsonPropertyName("end_date")]
    public DateTime EndDate { get; set; }
}
