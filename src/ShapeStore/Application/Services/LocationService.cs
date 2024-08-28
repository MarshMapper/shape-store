using FluentValidation;
using ShapeStore.Domain.Entities;
using ShapeStore.Application.Interfaces;
using ShapeStore.Application.Validators;

namespace ShapeStore.Application.Services
{
    public class LocationService : CrudService<Location>, ILocationService
    {
        public LocationService(IRepository<Location> repository) : base(repository)
        {
        }
        public override IValidator<Location> GetValidator()
        {
            return new LocationValidator();
        }
    }
}
