using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Models;

[Index(nameof(Name), nameof(MakeID), IsUnique = true)]
public class Model
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public int MakeID { get; set; }

    public Make Make { get; set; } = null!;

    public ICollection<ModelStyle> ModelStyles { get; set; } = null!;
}
