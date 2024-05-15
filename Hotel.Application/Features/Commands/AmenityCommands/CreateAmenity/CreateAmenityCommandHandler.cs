using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Amenities;
using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.CreateAmenity;

internal sealed class CreateAmenityCommandHandler(
    IAmenityRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAmenityCommand, int>
{
    public async Task<int> Handle(CreateAmenityCommand request, CancellationToken cancellationToken)
    {
        var isTitleUnique = await repository.IsTitleUniqueAsync(request.Title, cancellationToken);

        if (!isTitleUnique) throw new AlreadyExistsException("Amenity with this title is already exist");

        var newAmenity = new Amenity
        {
            Title = request.Title
        };

        await repository.CreateAsync(newAmenity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return newAmenity.Id;
    }
}