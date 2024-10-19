using Microsoft.EntityFrameworkCore;
using ShapeStore.Application.Interfaces;
using ShapeStore.Application.Services;
using ShapeStore.Domain.Entities;
using ShapeStore.Infrastructure.Repositories;
using ShapeStore.Infrastructure.Configuration;
using NetTopologySuite.IO.Converters;
using ShapeStore.Infrastructure.DbContexts;
using Microsoft.AspNetCore.OutputCaching;

namespace ShapeStore.Infrastructure
{
    public static class ShapeStoreExtensions
    {
        public static StoreOptions GetStoreOptions(ConfigurationManager configurationManager)
        {
            StoreOptions storeOptions = new();
            configurationManager.GetSection($"{StoreOptions.StoreSettignsSection}")
                .Bind(storeOptions);
            return storeOptions;
        }
        public static void AddShapeStore(this IServiceCollection services,
            ConfigurationManager configurationManager)
        {
            services.Configure<StoreOptions>(
                configurationManager.GetSection($"{StoreOptions.StoreSettignsSection}"));

            StoreOptions? storsSettings = GetStoreOptions(configurationManager);
            string storeType = storsSettings?.StoreType ?? "sql";
            string databaseName = storsSettings?.DatabaseName ?? "";

            switch (storeType)
            {
                case "sql":
                    services.AddDbContext<ShapeStoreContext>(
                        options => options.UseSqlServer(configurationManager.GetConnectionString("ShapeConnection"),
                            sqlServerOptions => sqlServerOptions.UseNetTopologySuite()));
                    break;
                case "cosmos":
                    string connectionString = configurationManager.GetConnectionString("ShapeConnection") ?? "";
                    services.AddDbContext<ShapeStoreContext>(
                        options => options.UseCosmos(
                            connectionString,
                            databaseName: databaseName,
                              cosmosOptionsAction: options =>
                              {
                                  options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
                                  options.MaxRequestsPerTcpConnection(16);
                                  options.MaxTcpConnectionsPerEndpoint(32);
                              }));
                    break;
            }

            services.AddScoped(typeof(ILocationRepository), typeof(LocationRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIconService, IconService>();
            services.AddScoped<IDistanceConverter, DistanceConverter>();

            // for minimal APIs, configure the GeoJSON converter
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new GeoJsonConverterFactory());
            });
        }
    }
}
