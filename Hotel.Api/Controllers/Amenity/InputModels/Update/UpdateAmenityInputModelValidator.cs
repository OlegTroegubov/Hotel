using FluentValidation;

namespace Hotel.Controllers.Amenity.InputModels.Update;

public sealed class UpdateAmenityInputModelValidator : AbstractValidator<UpdateAmenityInputModel>
{
    public UpdateAmenityInputModelValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Identifier should be greater than 0");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title should be not empty")
            .MaximumLength(100)
            .WithMessage("Title length cannot exceed 100 characters");
    }
}