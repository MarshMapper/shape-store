using Ardalis.Result.AspNetCore;
using ShapeStore.Domain.Entities;
using ShapeStore.Application.Interfaces;

namespace ShapeStore.Web.Endpoints
{
    public static class EndpointExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapLocationGroup();
            app.MapCategoryGroup();
            app.MapIconGroup();
        }
    }
}
