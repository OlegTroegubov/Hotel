using MediatR;

namespace Hotel.Application.Features.Queries.AmenityQueries.GetById;

internal sealed record GetAmenityByIdQuery(int Id) : IRequest<AmenityDto>;