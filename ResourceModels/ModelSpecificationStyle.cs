using System.ComponentModel.DataAnnotations;
using VehicleQuotes.Validations;

namespace VehicleQuotes.ResourceModels;

public class ModelSpecificationStyle
{
    [Required]
    [VehicleBodyType]
    public required string BodyType { get; set; }
    [Required]
    [VehicleSize]
    public required string Size { get; set; }

    [Required]
    [MinLength(1)]
    [ContainsYears]
    public required string[] Years { get; set; }
}
