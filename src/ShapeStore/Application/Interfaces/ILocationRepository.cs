using Ardalis.Result;
using ShapeStore.Application.Services;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Application.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<Result<IReadOnlyCollection<Location>>> GetAllAsync(ISpatialQuery? spatialQuery = null);
    }
}
