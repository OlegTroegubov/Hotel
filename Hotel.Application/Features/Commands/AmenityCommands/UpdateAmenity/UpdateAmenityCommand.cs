using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.UpdateAmenity;

internal sealed record UpdateAmenityCommand(int Id, string Title) : IRequest;