using System.ComponentModel.DataAnnotations;
using DigitalLibrary.Common.Domain.Shared;

namespace DigitalLibrary.Common.Domain.Extensions;

public static class ValidationExtensions
{
    public static Result<TPayload, Error> ValidatePayload<TPayload>(
        this TPayload payload) where TPayload : class
    {
        var validationResults = new List<ValidationResult>();

        if (!Validator.TryValidateObject(
                payload,
                new ValidationContext(payload),
                validationResults,
                validateAllProperties: true))
        {
            return new Error(
                "PayloadValidation.InvalidPayload",
                string.Join("\n", validationResults.Select(v => v.ErrorMessage)));
        }

        return payload;
    }
}
