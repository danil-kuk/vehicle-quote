using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace VehicleQuotes.Validations;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class ContainsYearsAttribute : ValidationAttribute
{
    private readonly string propertyName;

    public ContainsYearsAttribute([CallerMemberName] string propertyName = "")
    {
        this.propertyName = propertyName;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string[] array = value as string[] ?? Array.Empty<string>();
            bool isValid = array.All(IsValidYear);

            if (!isValid)
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        return ValidationResult.Success;
    }

    private bool IsValidYear(string value) =>
            !string.IsNullOrEmpty(value) && value.Length == 4 && value.All(char.IsDigit);

    private string GetErrorMessage() =>
        $"The {propertyName} field must be an array of strings containing four digits.";
}
