using MediatR;

namespace Hotel.Application.Features.Queries.VisitorQueries.GetById;

public sealed record GetVisitorByIdQuery : IRequest<VisitorDto>
{
    public required Guid Id { get; init; }
}