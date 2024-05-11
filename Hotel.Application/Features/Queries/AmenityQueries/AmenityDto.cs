using AutoMapper;
using Hotel.Domain.Entities.Amenities;

namespace Hotel.Application.Features.Queries.AmenityQueries;

public sealed class AmenityDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
}

internal sealed class AmenityDtoMapperProfile : Profile
{
    public AmenityDtoMapperProfile()
    {
        CreateMap<Amenity, AmenityDto>();
    }
}