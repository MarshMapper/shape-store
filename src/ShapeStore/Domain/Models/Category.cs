#nullable disable
namespace ShapeStore.Domain.Models;

public partial class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int? IconId { get; set; }
    public string Description { get; set; }
    public virtual Icon Icon { get; set; }
    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}