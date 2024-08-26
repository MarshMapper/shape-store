using ShapeStore.Domain.Entities;
using ShapeStore.Application.Interfaces;

namespace ShapeStore.Application.Services
{
    public class LocationService : CrudService<Location>, ILocationService
    {
        public LocationService(IRepository<Location> repository) : base(repository)
        {
        }
    }
}
