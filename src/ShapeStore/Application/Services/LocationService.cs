using FluentValidation;
using ShapeStore.Domain.Entities;
using ShapeStore.Application.Interfaces;
using ShapeStore.Application.Validators;
using Ardalis.Result;
using NetTopologySuite.Features;

namespace ShapeStore.Application.Services
{
    public class LocationService : CrudService<Location>, ILocationService
    {
        private ILocationRepository _repository;
        public LocationService(ILocationRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public override IValidator<Location> GetValidator()
        {
            return new LocationValidator();
        }
        // return all locations as a FeatureCollection, which will be serialized to GeoJSON
        public async Task<Result<FeatureCollection>> GetAllAsyncAsFeatureCollection(ISpatialQuery? spatialQuery = null)
        {
            FeatureCollection featureCollection = new FeatureCollection();
            var locationResult = await _repository.GetAllAsync(spatialQuery);
            if (locationResult.IsSuccess)
            {
                foreach (var location in locationResult.Value)
                {
                    featureCollection.Add(CreateFeature(location));
                }
                return Result<FeatureCollection>.Success(featureCollection);
            }
            return Result<FeatureCollection>.Error(new ErrorList(locationResult.Errors));
        }
        // create a Feature from a Location. the geometry comes directly from the Location, the attributes table is
        // populated with the Location's other properties.
        public Feature CreateFeature(Location location)
        {
            return new Feature
            {
                Geometry = location.Geometry,
                Attributes = new AttributesTable
                {
                    { "name", location.Name },
                    { "address", location.Address1 },
                    { "address2", location.Address2 },
                    { "city", location.City },
                    { "state", location.State },
                    { "postalCode", location.PostalCode },
                    { "phone", location.Phone },
                    { "phone2", location.Phone2 },
                    { "url", location.Url },
                    { "isOpen", location.IsOpen },
                    { "categoryId", location.CategoryId },
                    { "iconId", location.IconId },
                    { "notes", location.Notes },
                }
            };
        }
    }
}
