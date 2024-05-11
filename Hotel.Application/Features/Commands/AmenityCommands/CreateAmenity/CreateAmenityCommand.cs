using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.CreateAmenity;

public class CreateAmenityCommand : IRequest<int>
{
    public required string Title { get; init; }
}