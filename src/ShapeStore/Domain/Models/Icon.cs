#nullable disable
namespace ShapeStore.Domain.Models;

public partial class Icon
{
    public int IconId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}