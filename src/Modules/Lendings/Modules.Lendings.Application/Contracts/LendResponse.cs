using System.Text.Json.Serialization;
using DigitalLibrary.Modules.Lendings.Domain.Enumerations;

namespace DigitalLibrary.Modules.Lendings.Application.Contracts;

public class LendContracts
{
    public class LendResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public LendStatuses Status { get; set; }

        [JsonPropertyName("book_id")]
        public Guid BookId { get; set; }

        [JsonPropertyName("patron_id")]
        public Guid PatronId { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; private set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; private set; }

        [JsonPropertyName("created_date")]
        public DateTime CreatedDate { get; private set; }

        [JsonPropertyName("concluded_date")]
        public DateTime? ConcludedDate { get; private set; }

        [JsonPropertyName("cancelled_date")]
        public DateTime? CancelledDate { get; private set; }
    }
}
