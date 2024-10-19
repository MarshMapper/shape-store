#nullable disable
using Microsoft.EntityFrameworkCore;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Infrastructure.DbContexts;

// model creator class for relational databases
public class SqlModelCreator : IModelCreator
{
    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        // categories of locations.  these may vary based on the application
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
        // available icons
        modelBuilder.Entity<Icon>(entity =>
        {
            entity.ToTable("Icon");

            entity.Property(e => e.IconId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });
        // one location including a shape representing its location or boundary
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
            entity.Property(e => e.Geometry).HasColumnType("geography");

            entity.HasOne(d => d.Category).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Location_Category");
        });
    }
}