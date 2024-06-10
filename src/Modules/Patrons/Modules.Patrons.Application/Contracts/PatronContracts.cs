using System.Text.Json.Serialization;

namespace DigitalLibrary.Modules.Patrons.Application.Contracts;

public static class PatronContracts
{
    public class PatronResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("registration_number")]
        public long RegistrationNumber { get; private set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; private set; } = string.Empty;

        [JsonPropertyName("middle_name")]
        public string? MiddleName { get; private set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; private set; } = string.Empty;

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; private set; }
    }
}
