using Ardalis.Result;
using NetTopologySuite.Features;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Application.Interfaces
{
    public interface ILocationService : ICrudService<Location>
    {
        Task<Result<FeatureCollection>> GetAllAsyncAsFeatureCollection();
    }
}
