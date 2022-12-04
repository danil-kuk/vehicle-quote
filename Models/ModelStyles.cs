using Microsoft.EntityFrameworkCore;

namespace VehicleQuotes.Models;

[Index(nameof(ModelID), nameof(BodyTypeID), nameof(SizeID), IsUnique = true)]
public class ModelStyle
{
    public int ID { get; set; }
    public int ModelID { get; set; }
    public int BodyTypeID { get; set; }
    public int SizeID { get; set; }

    public Model Model { get; set; } = null!;
    public BodyType BodyType { get; set; } = null!;
    public Size Size { get; set; } = null!;

    public ICollection<ModelStyleYear> ModelStyleYears { get; set; } = null!;
}
