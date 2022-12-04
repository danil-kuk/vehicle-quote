using System.ComponentModel.DataAnnotations;
using VehicleQuotes.Data;

namespace VehicleQuotes.Validations;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class VehicleSizeAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        var dbContext = validationContext.GetService(typeof(VehicleQuotesContext)) as VehicleQuotesContext;
        var sizes = dbContext?.Sizes.Select(size => size.Name).ToList();

        if (sizes?.Contains(value) == false)
        {
            string allowed = string.Join(", ", sizes);
            return new ValidationResult(
                $"Invalid vehicle size {value}. Allowed values are {allowed}."
            );
        }

        return ValidationResult.Success;
    }
}
