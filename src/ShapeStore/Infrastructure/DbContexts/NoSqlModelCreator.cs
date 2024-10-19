#nullable disable
using Microsoft.EntityFrameworkCore;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Infrastructure.DbContexts;

// model creator class for NoSQL / document data store
public class NoSqlModelCreator : IModelCreator
{ 
    // adopt the .NET 9 convention to avoid need to update later
    private const string _discriminatorColumnName = "$type";
    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultContainer("locations");

        // categories of locations.  these may vary based on the application
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasDiscriminator<string>(_discriminatorColumnName)
                .HasValue<Category>("category");
        });
        // available icons
        modelBuilder.Entity<Icon>(entity =>
        {
            entity.HasDiscriminator<string>(_discriminatorColumnName)
                .HasValue<Icon>("icon");
        });
        // one location including a shape representing its location or boundary
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasDiscriminator<string>(_discriminatorColumnName)
                .HasValue<Location>("location");
        });
    }
}