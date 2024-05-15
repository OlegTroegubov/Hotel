using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.UpdateAmenity;

public sealed record UpdateAmenityCommand : IRequest
{
    public int Id { get; init; }
    public required string Title { get; init; }
}