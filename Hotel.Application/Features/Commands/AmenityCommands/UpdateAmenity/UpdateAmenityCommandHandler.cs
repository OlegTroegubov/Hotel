using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Amenities;
using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.UpdateAmenity;

internal sealed class UpdateAmenityCommandHandler
    (IAmenityRepository repository, IUnitOfWork unitOfWork) 
    : IRequestHandler<UpdateAmenityCommand>
{
    public async Task Handle(UpdateAmenityCommand request, CancellationToken cancellationToken)
    {
        Amenity? amenity = await repository.GetByIdAsync(request.Id, cancellationToken);
        
        if (amenity is null) throw new NotFoundException("Amenity was not found");

        bool isTitleUnique = await repository.IsTitleUniqueAsync(request.Title, cancellationToken);

        if (!isTitleUnique) throw new AlreadyExistsException("Amenity with this title is already exist");
        
        amenity.Title = request.Title;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}