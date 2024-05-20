using MediatR;

namespace Hotel.Application.Features.Commands.VisitorCommands.DeleteVisitor;

public sealed record DeleteVisitorCommand : IRequest
{
    public required Guid Id { get; init; }
}