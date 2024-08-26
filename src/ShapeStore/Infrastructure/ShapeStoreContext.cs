#nullable disable
using Microsoft.EntityFrameworkCore;
using ShapeStore.Domain.Models;

namespace ShapeStore.Infrastructure;

public partial class ShapeStoreContext : DbContext
{
    public ShapeStoreContext(DbContextOptions<ShapeStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Icon> Icons { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Icon).WithMany(p => p.Categories)
                .HasForeignKey(d => d.IconId)
                .HasConstraintName("FK_Category_Icon");
        });

        modelBuilder.Entity<Icon>(entity =>
        {
            entity.ToTable("Icon");

            entity.Property(e => e.IconId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.Address1).HasMaxLength(256);
            entity.Property(e => e.Address2).HasMaxLength(256);
            entity.Property(e => e.City).HasMaxLength(96);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Notes).HasMaxLength(1024);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(16);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Url).HasMaxLength(512);
            entity.Property(e => e.Coordinates).HasColumnType("geography");

            entity.HasOne(d => d.Category).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Location_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}