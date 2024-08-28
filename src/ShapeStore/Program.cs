using ShapeStore.Infrastructure;
using ShapeStore.Web.Endpoints;

namespace ShapeStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add and configure the services provided by the ShapeStore
            builder.Services.AddShapeStore(builder.Configuration);

            var app = builder.Build();

            // add the ShapeStore endpoints 
            app.MapEndpoints();

            app.Run();
        }
    }
}
