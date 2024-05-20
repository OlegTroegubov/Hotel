namespace Hotel.Domain.Entities.Visitor;

public interface IVisitorRepository
{
    Task CreateAsync(Visitor visitor, CancellationToken cancellationToken);
    void Delete(Visitor visitor);
    Task<Visitor?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> IsPhoneIsUniqueAsync(string phone, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visitor>> GetAllAsync(CancellationToken cancellationToken);
}