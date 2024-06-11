using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Common.Domain.Attributes;

public class NotEmptyGuidAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            ErrorMessage = "Value cannot be null";
            return false;
        }

        if (!Guid.TryParse(value.ToString(), out Guid result))
        {
            ErrorMessage = "Value must be GUID";
            return false;
        }

        if (result.Equals(Guid.Empty))
        {
            ErrorMessage = "Value cannot be a empty GUID";
            return false;            
        }

        return true;
    }
}
