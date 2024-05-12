using FluentValidation;

namespace Hotel.Controllers.Amenity.InputModels.Delete;

public sealed class DeleteAmenityInputModelValidator : AbstractValidator<DeleteAmenityInputModel>
{
    public DeleteAmenityInputModelValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Identifier should be greater than 0");
    }
}