using Hotel.Domain.Entities.Visitor;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence.Repositories;

internal sealed class VisitorRepository(ApplicationDbContext context) : IVisitorRepository
{
    public async Task CreateAsync(Visitor visitor, CancellationToken cancellationToken)
    {
        await context.Visitors.AddAsync(visitor, cancellationToken);
    }

    public void Delete(Visitor visitor)
    {
        context.Visitors.Remove(visitor);
    }

    public async Task<Visitor?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Visitors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> IsPhoneIsUniqueAsync(string phone, CancellationToken cancellationToken)
    {
        return await context.Visitors.AnyAsync(x => x.Phone == phone, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Visitor>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Visitors.AsNoTracking().ToListAsync(cancellationToken);
    }
}