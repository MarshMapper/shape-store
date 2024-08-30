using ShapeStore.Application.Interfaces;

namespace ShapeStore.Application.Services
{
    public class SpatialQuery : ISpatialQuery
    {
        public SpatialQuery(SpatialQueryType type, double? latitude, double? longitude, double? radius)
        {
            Type = type;
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
        }

        public SpatialQueryType Type { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Radius { get; set; }
    }
}
