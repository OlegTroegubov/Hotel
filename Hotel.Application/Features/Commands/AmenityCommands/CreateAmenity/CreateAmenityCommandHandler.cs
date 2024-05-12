using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Amenities;
using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.CreateAmenity;

internal class CreateAmenityCommandHandler(
    IAmenityRepository repository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateAmenityCommand, int>
{
    public async Task<int> Handle(CreateAmenityCommand request, CancellationToken cancellationToken)
    {
        Amenity? amenity = await repository.GetByTitleAsync(request.Title, cancellationToken);

        if (amenity is not null) throw new AlreadyExistsException("Amenity with this title is already exist");

        Amenity newAmenity = new Amenity
        {
            Title = request.Title
        };

        await repository.CreateAsync(newAmenity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return newAmenity.Id;
    }
}