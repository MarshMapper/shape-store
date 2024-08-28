using Ardalis.Result.AspNetCore;
using ShapeStore.Domain.Entities;
using ShapeStore.Application.Interfaces;

namespace ShapeStore.Web.Endpoints
{
    public static class IconEndpoints
    {
        public static void MapIconGroup(this WebApplication app)
        {
            app.MapGroup("/icons")
                .MapIconEndpoints();
        }
        public static RouteGroupBuilder MapIconEndpoints(this RouteGroupBuilder iconGroup)
        {
            iconGroup.MapGet("", async (IIconService iconService) =>
            {
                return (await iconService.GetAllAsync()).ToMinimalApiResult();
            });
            iconGroup.MapPut("", async (IIconService iconService, Icon icon) =>
            {
                return (await iconService.UpdateAsync(icon)).ToMinimalApiResult();
            });
            iconGroup.MapPost("", async (IIconService iconService, Icon icon) =>
            {
                return (await iconService.AddAsync(icon)).ToMinimalApiResult();
            });
            iconGroup.MapGet("{id}", async (IIconService iconService, int id) =>
            {
                return (await iconService.GetByIdAsync(id)).ToMinimalApiResult();
            });
            iconGroup.MapDelete("{id}", async (IIconService iconService, int id) =>
            {
                return (await iconService.DeleteAsync(id)).ToMinimalApiResult();
            });
            return iconGroup;
        }
    }
}
