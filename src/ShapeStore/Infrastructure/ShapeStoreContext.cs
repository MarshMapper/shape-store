#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShapeStore.Domain.Entities;
using ShapeStore.Infrastructure.Configuration;
using ShapeStore.Infrastructure.DbContexts;

namespace ShapeStore.Infrastructure;

public partial class ShapeStoreContext : DbContext
{
    private readonly StoreOptions _storeOptions;

    public ShapeStoreContext(DbContextOptions<ShapeStoreContext> options, IOptions<StoreOptions> storeOptions)
        : base(options)
    {
        _storeOptions = storeOptions.Value;
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Icon> Icons { get; set; }

    public virtual DbSet<Location> Locations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        GetModelCreator().OnModelCreating(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }
    protected IModelCreator GetModelCreator()
    {
        return _storeOptions.StoreType switch
        {
            "cosmos" => new NoSqlModelCreator(),
            _ => new SqlModelCreator()
        };
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
