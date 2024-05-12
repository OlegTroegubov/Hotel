using FluentValidation;

namespace Hotel.Controllers.Amenity.InputModels.Create;

public sealed class CreateAmenityInputModelValidator : AbstractValidator<CreateAmenityInputModel>
{
    public CreateAmenityInputModelValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title should be not empty")
            .MaximumLength(100)
            .WithMessage("Title length cannot exceed 100 characters");
    }
}