using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Visitor;
using MediatR;

namespace Hotel.Application.Features.Commands.VisitorCommands.DeleteVisitor;

internal sealed class DeleteVisitorCommandHandler(IVisitorRepository repository, IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteVisitorCommand>
{
    public async Task Handle(DeleteVisitorCommand request, CancellationToken cancellationToken)
    {
        Visitor? visitor = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (visitor is null) throw new NotFoundException("Visitor was not found");

        repository.Delete(visitor);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}