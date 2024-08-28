#nullable disable
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using System.Text.Json.Serialization;
namespace ShapeStore.Domain.Entities;

public partial class Location
{
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Phone2 { get; set; }
    public string Url { get; set; }
    public bool? IsOpen { get; set; }
    public int? CategoryId { get; set; }
    public int? IconId { get; set; }
    public string Notes { get; set; }
    [JsonConverter(typeof(GeoJsonConverterFactory))]
    public Geometry Geometry { get; set; }
    [JsonIgnore]
    public virtual Category Category { get; set; }
}