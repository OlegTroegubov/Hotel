using AutoMapper;
using Hotel.Domain.Entities.Amenities;
using MediatR;

namespace Hotel.Application.Features.Queries.AmenityQueries.Get;

internal sealed class GetAmenitiesQueryHandler(IAmenityRepository repository, IMapper mapper) 
    : IRequestHandler<GetAmenitiesQuery, IReadOnlyCollection<AmenityDto>>
{
    public async Task<IReadOnlyCollection<AmenityDto>> Handle(GetAmenitiesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Amenity> amenities = await repository.GetAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<Amenity>, IReadOnlyCollection<AmenityDto>>(amenities);
    }
}