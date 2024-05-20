using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.DeleteAmenity;

public sealed record DeleteAmenityCommand : IRequest
{
    public required int Id { get; init; }
}