using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Modules.Patrons.Endpoints.Contracts;

public class RegisterPatronRequest
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public DateTime Birthday { get; set; }
}
