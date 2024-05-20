using MediatR;

namespace Hotel.Application.Features.Commands.VisitorCommands.CreateVisitor;

public class CreateVisitorCommand : IRequest<Guid>
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; }
    public required string Phone { get; init; }
    public string? Email { get; init; }
}