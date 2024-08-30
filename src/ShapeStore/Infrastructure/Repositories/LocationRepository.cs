using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using ShapeStore.Application.Interfaces;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Infrastructure.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(ShapeStoreContext context) : base(context)
        {
        }
        public async Task<Result<IReadOnlyCollection<Location>>> GetAllAsync(ISpatialQuery? spatialQuery = null)
        { 
            if (spatialQuery == null)
            {
                return await base.GetAllAsync();
            }
            try
            {
                if (spatialQuery.Type != SpatialQueryType.WithinRadius)
                {
                    return Result<IReadOnlyCollection<Location>>.Error("Query type not implemented");
                }
                if (!spatialQuery.Latitude.HasValue || !spatialQuery.Longitude.HasValue || !spatialQuery.Radius.HasValue)
                {
                    return Result<IReadOnlyCollection<Location>>.Error("Latitude, longitude, and radius are required");
                }
                var point = new NetTopologySuite.Geometries.Point(spatialQuery.Longitude.Value, spatialQuery.Latitude.Value) { SRID = 4326 };

                // EF Core / NTS will convert this to a spatial query
                var locations = await _context.Locations
                    .Where(l => l.Geometry.IsWithinDistance(point, spatialQuery.Radius.Value))
                    .ToListAsync();
                return Result<IReadOnlyCollection<Location>>.Success(locations);
            }
            catch (Exception ex)
            {
                return Result<IReadOnlyCollection<Location>>.Error(ex.Message);
            }
        }
    }
}
