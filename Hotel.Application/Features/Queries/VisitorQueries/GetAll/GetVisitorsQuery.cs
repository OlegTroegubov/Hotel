using MediatR;

namespace Hotel.Application.Features.Queries.VisitorQueries.GetAll;

public sealed record GetVisitorsQuery : IRequest<IReadOnlyCollection<VisitorDto>>;