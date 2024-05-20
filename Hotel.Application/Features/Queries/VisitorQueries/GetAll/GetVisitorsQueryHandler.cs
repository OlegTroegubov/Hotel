using AutoMapper;
using Hotel.Domain.Entities.Visitor;
using MediatR;

namespace Hotel.Application.Features.Queries.VisitorQueries.GetAll;

internal sealed class GetVisitorsQueryHandler(IVisitorRepository repository, IMapper mapper) : IRequestHandler<GetVisitorsQuery, IReadOnlyCollection<VisitorDto>>
{
    public async Task<IReadOnlyCollection<VisitorDto>> Handle(GetVisitorsQuery request, CancellationToken cancellationToken)
    {
        var visitors  = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<Visitor>, IReadOnlyCollection<VisitorDto>>(visitors);
    }
}