using FluentValidation;
using ShapeStore.Application.Interfaces;
using ShapeStore.Application.Validators;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Application.Services
{
    public class CategoryService : CrudService<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }
        public override IValidator<Category> GetValidator()
        {
            return new CategoryValidator();
        }
    }
}
