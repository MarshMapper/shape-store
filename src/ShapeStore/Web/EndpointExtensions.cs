using Ardalis.Result.AspNetCore;
using ShapeStore.Domain.Models;
using ShapeStore.Infrastructure.Repositories;

namespace ShapeStore.Web
{
    public static class EndpointExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapLocationGroup();
        }
        public static void MapLocationGroup(this WebApplication app)
        {
            app.MapGroup("/locations")
                .MapLocationEndpoints();
        }
        public static RouteGroupBuilder MapLocationEndpoints(this RouteGroupBuilder locationGroup)
        {
            locationGroup.MapGet("", async (Repository<Location> repository) =>
            {
                return (await repository.GetAllAsync()).ToMinimalApiResult();
            });
            locationGroup.MapPut("", async (Repository<Location> repository, Location location) =>
            {
                return (await repository.UpdateAsync(location)).ToMinimalApiResult();
            });
            locationGroup.MapPost("", async (Repository<Location> repository, Location location) =>
            {
                return (await repository.AddAsync(location)).ToMinimalApiResult();
            });
            locationGroup.MapGet("{id}", async (Repository<Location> repository, int id) =>
            {
                return (await repository.GetByIdAsync(id)).ToMinimalApiResult();
            });
            locationGroup.MapDelete("{id}", async (Repository<Location> repository, int id) =>
            {
                return (await repository.DeleteAsync(id)).ToMinimalApiResult();
            });
            return locationGroup;
        }
    }
}
