using Hotel.Application.Common.Exceptions;
using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Visitor;
using MediatR;

namespace Hotel.Application.Features.Commands.VisitorCommands.CreateVisitor;

internal sealed class CreateVisitorCommandHandler(IVisitorRepository repository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateVisitorCommand, Guid>
{
    public async Task<Guid> Handle(CreateVisitorCommand request, CancellationToken cancellationToken)
    {
        var isPhoneIsUnique = await repository.IsPhoneIsUniqueAsync(request.Phone, cancellationToken);

        if (!isPhoneIsUnique) throw new AlreadyExistsException("Visitor with this phone is already exist");
        
        Visitor visitor = new Visitor
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            Phone = request.Phone,
            Email = request.Email
        };
        
        await repository.CreateAsync(visitor, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return visitor.Id;
    }
}