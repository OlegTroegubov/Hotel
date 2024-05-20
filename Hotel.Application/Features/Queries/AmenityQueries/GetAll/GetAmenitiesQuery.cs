using MediatR;

namespace Hotel.Application.Features.Queries.AmenityQueries.GetAll;

public sealed class GetAmenitiesQuery : IRequest<IReadOnlyCollection<AmenityDto>>;