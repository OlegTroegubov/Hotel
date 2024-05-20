using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Visitor;
using MediatR;

namespace Hotel.Application.Features.Commands.VisitorCommands.UpdateVisitor;

internal sealed class UpdateVisitorCommandHandler(IVisitorRepository repository, IUnitOfWork unitOfWork) 
    : IRequestHandler<UpdateVisitorCommand>
{
    public async Task Handle(UpdateVisitorCommand request, CancellationToken cancellationToken)
    {
        Visitor? visitor = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (visitor is null) throw new NotFoundException("Visitor was not found");
        
        if (request.Phone is not null) visitor.Phone = request.Phone;
        if (request.LastName is not null) visitor.LastName = request.LastName;
        if (request.FirstName is not null) visitor.FirstName = request.FirstName;

        visitor.MiddleName = request.MiddleName;
        visitor.Email = request.Email;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}