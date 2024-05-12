using MediatR;

namespace Hotel.Application.Features.Queries.AmenityQueries.Get;

public sealed class GetAmenitiesQuery : IRequest<IReadOnlyCollection<AmenityDto>>;