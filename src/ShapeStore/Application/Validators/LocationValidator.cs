using FluentValidation;
using ShapeStore.Domain.Entities;

namespace ShapeStore.Application.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Phone).MaximumLength(20).WithMessage("Phone number must be 20 characters or less");
            RuleFor(x => x.Phone2).MaximumLength(50).WithMessage("Phone2 number must be 50 characters or less");
            RuleFor(x => x.Address1).MaximumLength(256).WithMessage("Address1 must be 256 characters or less");
            RuleFor(x => x.Address2).MaximumLength(256).WithMessage("Address2 must be 256 characters or less");
            RuleFor(x => x.City).MaximumLength(96).WithMessage("City must be 96 characters or less");
            RuleFor(x => x.State).MaximumLength(50).WithMessage("State must be 50 characters or less");
            RuleFor(x => x.PostalCode).MaximumLength(16).WithMessage("PostalCode must be 16 characters or less");
            RuleFor(x => x.Url).MaximumLength(512).WithMessage("Url must be 512 characters or less");
            RuleFor(x => x.Notes).MaximumLength(1024).WithMessage("Notes must be 1024 characters or less");
        }
    }
}
