using FluentValidation;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Application.Validators
{
    public class IconValidator : AbstractValidator<Icon>
    {
        public IconValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name must be 50 characters or less");
            RuleFor(x => x.Description).MaximumLength(256).WithMessage("Description must be 256 characters or less");
        }
    }
}
