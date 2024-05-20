using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.CreateAmenity;

public sealed record CreateAmenityCommand : IRequest<int>
{
    public required string Title { get; init; }
}