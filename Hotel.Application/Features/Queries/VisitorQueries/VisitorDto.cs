using AutoMapper;
using Hotel.Domain.Entities.Visitor;

namespace Hotel.Application.Features.Queries.VisitorQueries;

public sealed class VisitorDto
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; }
    public required string Phone { get; init; }
    public string? Email { get; init; }
}

internal sealed class VisitorDtoMapperProfile : Profile
{
    public VisitorDtoMapperProfile()
    {
        CreateMap<Visitor, VisitorDto>();
    }
}