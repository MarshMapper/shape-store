using FluentValidation;
using ShapeStore.Application.Interfaces;
using ShapeStore.Application.Validators;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Application.Services
{
    public class IconService : CrudService<Icon>, IIconService
    {
        public IconService(IRepository<Icon> repository) : base(repository)
        {
        }
        public override IValidator<Icon> GetValidator()
        {
            return new IconValidator();
        }
    }
}
