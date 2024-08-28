#nullable disable
using System.Text.Json.Serialization;

namespace ShapeStore.Domain.Entities;

public partial class Icon
{
    public int IconId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}