using MediatR;

namespace Hotel.Application.Features.Commands.VisitorCommands.UpdateVisitor;

public sealed record UpdateVisitorCommand : IRequest
{
    public required Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? MiddleName { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
}