using Ardalis.Result.AspNetCore;
using ShapeStore.Domain.Entities;
using ShapeStore.Application.Interfaces;

namespace ShapeStore.Web.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryGroup(this WebApplication app)
        {
            app.MapGroup("/categories")
                .MapCategoryEndpoints();
        }
        public static RouteGroupBuilder MapCategoryEndpoints(this RouteGroupBuilder categoryGroup)
        {
            categoryGroup.MapGet("", async (ICategoryService categoryService) =>
            {
                return (await categoryService.GetAllAsync()).ToMinimalApiResult();
            });
            categoryGroup.MapPut("", async (ICategoryService categoryService, Category category) =>
            {
                return (await categoryService.UpdateAsync(category)).ToMinimalApiResult();
            });
            categoryGroup.MapPost("", async (ICategoryService categoryService, Category category) =>
            {
                return (await categoryService.AddAsync(category)).ToMinimalApiResult();
            });
            categoryGroup.MapGet("{id}", async (ICategoryService categoryService, int id) =>
            {
                return (await categoryService.GetByIdAsync(id)).ToMinimalApiResult();
            });
            categoryGroup.MapDelete("{id}", async (ICategoryService categoryService, int id) =>
            {
                return (await categoryService.DeleteAsync(id)).ToMinimalApiResult();
            });
            return categoryGroup;
        }
    }
}
