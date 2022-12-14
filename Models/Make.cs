using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Models;

[Index(nameof(Name), IsUnique = true)]
public class Make
{
    public int ID { get; set; }
    public required string Name { get; set; }
}
