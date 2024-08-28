#nullable disable
using System.Text.Json.Serialization;

namespace ShapeStore.Domain.Entities;

public partial class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int? IconId { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public virtual Icon Icon { get; set; }
    [JsonIgnore]
    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}