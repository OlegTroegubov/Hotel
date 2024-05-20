using AutoMapper;
using Hotel.Domain.Entities.Visitor;
using MediatR;

namespace Hotel.Application.Features.Queries.VisitorQueries.GetById;

internal sealed class GetVisitorByIdQueryHandler(IVisitorRepository repository, IMapper mapper) : IRequestHandler<GetVisitorByIdQuery, VisitorDto>
{
    public async Task<VisitorDto> Handle(GetVisitorByIdQuery request, CancellationToken cancellationToken)
    {
        Visitor? visitor = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (visitor is null) throw new Exception("Visitor was not found");

        return mapper.Map<VisitorDto>(visitor);
    }
}