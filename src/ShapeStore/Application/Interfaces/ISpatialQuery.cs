namespace ShapeStore.Application.Interfaces
{
    public enum SpatialQueryType
    {
        None,
        WithinRadius,
        Intersects
    }
    public interface ISpatialQuery
    {
        SpatialQueryType Type { get; set; }
        DistanceUnit DistanceUnit { get; set; }
        double? Latitude { get; set; }
        double? Longitude { get; set; }
        double? Radius { get; set; }
    }
}
