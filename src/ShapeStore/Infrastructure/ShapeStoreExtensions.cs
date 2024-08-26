using Microsoft.EntityFrameworkCore;
using ShapeStore.Application.Interfaces;
using ShapeStore.Application.Services;
using ShapeStore.Domain.Entities;
using ShapeStore.Infrastructure.Repositories;
using NetTopologySuite.IO.Converters;

namespace ShapeStore.Infrastructure
{
    public static class ShapeStoreExtensions
    {
        public static void AddShapeStore(this IServiceCollection services,
            ConfigurationManager configurationManager)
        {
            services.AddDbContext<ShapeStoreContext>(
                options => options.UseSqlServer(configurationManager.GetConnectionString("ShapeConnection"),
                    sqlServerOptions => sqlServerOptions.UseNetTopologySuite()));

            services.AddScoped(typeof(Repository<Location>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILocationService, LocationService>();

            // for minimal APIs, configure the GeoJSON converter
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new GeoJsonConverterFactory());
            });
        }
    }
}
