using MediatR;

namespace Hotel.Application.Features.Queries.AmenityQueries.Get;

internal sealed record GetAmenitiesQuery : IRequest<IReadOnlyCollection<AmenityDto>>;