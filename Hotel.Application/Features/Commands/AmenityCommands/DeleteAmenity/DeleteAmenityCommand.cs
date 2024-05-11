using MediatR;

namespace Hotel.Application.Features.Commands.AmenityCommands.DeleteAmenity;

internal sealed record DeleteAmenityCommand(int Id) : IRequest; 