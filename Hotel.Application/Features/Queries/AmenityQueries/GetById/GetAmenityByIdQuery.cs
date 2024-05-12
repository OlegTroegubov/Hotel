using MediatR;

namespace Hotel.Application.Features.Queries.AmenityQueries.GetById;

public sealed class GetAmenityByIdQuery : IRequest<AmenityDto>
{
    public int Id { get; init; }
}