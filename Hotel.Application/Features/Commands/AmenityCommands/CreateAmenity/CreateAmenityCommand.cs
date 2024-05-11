using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.CreateAmenity;

internal sealed record CreateAmenityCommand(string Title) : IRequest<int>;