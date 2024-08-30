using Ardalis.Result.AspNetCore;
using ShapeStore.Domain.Entities;
using ShapeStore.Application.Interfaces;
using ShapeStore.Application.Services;

namespace ShapeStore.Web.Endpoints
{
    public static class LocationEndpoints
    {
        public static void MapLocationGroup(this WebApplication app)
        {
            app.MapGroup("/locations")
                .MapLocationEndpoints();
        }
        public static RouteGroupBuilder MapLocationEndpoints(this RouteGroupBuilder locationGroup)
        {
            locationGroup.MapGet("", async (ILocationService locationService) =>
            {
                return (await locationService.GetAllAsync()).ToMinimalApiResult();
            });
            // get locations as GeoJSON, optionally filtering results by distance from a given point
            locationGroup.MapGet("geojson", async (ILocationService locationService, double? radius = null, double? lat = null, double? lon = null) =>
            {
                SpatialQuery? spatialQuery = null;

                if (radius.HasValue || lat.HasValue || lon.HasValue)
                {
                    spatialQuery = new SpatialQuery(SpatialQueryType.WithinRadius, lat, lon, radius);
                }
                return (await locationService.GetAllAsyncAsFeatureCollection(spatialQuery)).ToMinimalApiResult();
            });
            locationGroup.MapPut("", async (ILocationService locationService, Location location) =>
            {
                return (await locationService.UpdateAsync(location)).ToMinimalApiResult();
            });
            locationGroup.MapPost("", async (ILocationService locationService, Location location) =>
            {
                return (await locationService.AddAsync(location)).ToMinimalApiResult();
            });
            locationGroup.MapGet("{id}", async (ILocationService locationService, int id) =>
            {
                return (await locationService.GetByIdAsync(id)).ToMinimalApiResult();
            });
            locationGroup.MapDelete("{id}", async (ILocationService locationService, int id) =>
            {
                return (await locationService.DeleteAsync(id)).ToMinimalApiResult();
            });
            return locationGroup;
        }
    }
}
