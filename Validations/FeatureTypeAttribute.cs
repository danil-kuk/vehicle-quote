using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VehicleQuotes.Models;

namespace VehicleQuotes.Validation;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class FeatureTypeAttribute : ValidationAttribute
{
    private static string AllowedValuesAsString => string.Join(", ", QuoteRule.FeatureTypes.All);

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        bool isValid = QuoteRule.FeatureTypes.All.Contains((string)value);

        if (!isValid) return new ValidationResult(GetErrorMessage((string)value));

        return ValidationResult.Success;
    }

    private static string GetErrorMessage(string value) =>
        $"{value} is not a valid feature type. Allowed values are: {AllowedValuesAsString}.";
}
