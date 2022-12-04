using System.ComponentModel.DataAnnotations;
using VehicleQuotes.Data;

namespace VehicleQuotes.Validations;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class VehicleBodyTypeAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        var dbContext = validationContext.GetService(typeof(VehicleQuotesContext)) as VehicleQuotesContext;
        var bodyTypes = dbContext?.BodyTypes.Select(type => type.Name).ToList();

        if (bodyTypes != null && bodyTypes?.Contains(value) == false)
        {
            string allowed = string.Join(", ", bodyTypes);
            return new ValidationResult(
                $"Invalid vehicle body type {value}. Allowed values are {allowed}."
            );
        }

        return ValidationResult.Success;
    }
}
