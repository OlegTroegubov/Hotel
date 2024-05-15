using AutoMapper;
using Hotel.Application.Common.Exceptions;
using Hotel.Domain.Entities.Amenities;
using MediatR;

namespace Hotel.Application.Features.Queries.AmenityQueries.GetById;

internal sealed class GetAmenityByIdQueryHandler(IAmenityRepository repository, IMapper mapper)
    : IRequestHandler<GetAmenityByIdQuery, AmenityDto>
{
    public async Task<AmenityDto> Handle(GetAmenityByIdQuery request, CancellationToken cancellationToken)
    {
        var amenity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (amenity is null) throw new NotFoundException("Amenity was not found");

        return mapper.Map<Amenity, AmenityDto>(amenity);
    }
}