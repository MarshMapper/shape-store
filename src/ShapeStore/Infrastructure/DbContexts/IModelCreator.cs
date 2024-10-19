using Microsoft.EntityFrameworkCore;

namespace ShapeStore.Infrastructure.DbContexts
{
    public interface IModelCreator
    {
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}