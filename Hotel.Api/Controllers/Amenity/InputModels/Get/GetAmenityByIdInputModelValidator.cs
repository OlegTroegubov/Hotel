using FluentValidation;

namespace Hotel.Controllers.Amenity.InputModels.Get;

public sealed class GetAmenityByIdInputModelValidator : AbstractValidator<GetAmenityByIdInputModel>
{
    public GetAmenityByIdInputModelValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Identifier should be greater than 0");
    }
}