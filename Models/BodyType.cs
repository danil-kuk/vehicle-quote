using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Models;

[Index(nameof(Name), IsUnique = true)]
public class BodyType
{
    public int ID { get; set; }
    public required string Name { get; set; }
}
