using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Common.Domain.Attributes;

public sealed class GreaterThanZero : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            ErrorMessage = "Value cannot be null";
            return false;
        }

        if (!int.TryParse(value.ToString(), out int result))
        {
            ErrorMessage = "Value must be numeric";
            return false;
        }

        if (result <= 0)
        {
            ErrorMessage = "Value must be greater than zero";
            return false;
        }

        return true;
    }
}
