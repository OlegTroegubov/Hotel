using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Amenities;
using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.DeleteAmenity;

internal sealed class DeleteAmenityCommandHandler(IAmenityRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAmenityCommand>
{
    public async Task Handle(DeleteAmenityCommand request, CancellationToken cancellationToken)
    {
        var amenity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (amenity is null) throw new NotFoundException("Amenity was not found");

        repository.Delete(amenity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}