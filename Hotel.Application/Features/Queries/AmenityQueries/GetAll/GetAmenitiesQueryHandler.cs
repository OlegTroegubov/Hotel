using AutoMapper;
using Hotel.Domain.Entities.Amenities;
using MediatR;

namespace Hotel.Application.Features.Queries.AmenityQueries.GetAll;

internal sealed class GetAmenitiesQueryHandler(IAmenityRepository repository, IMapper mapper)
    : IRequestHandler<GetAmenitiesQuery, IReadOnlyCollection<AmenityDto>>
{
    public async Task<IReadOnlyCollection<AmenityDto>> Handle(GetAmenitiesQuery request,
        CancellationToken cancellationToken)
    {
        var amenities = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<Amenity>, IReadOnlyCollection<AmenityDto>>(amenities);
    }
}