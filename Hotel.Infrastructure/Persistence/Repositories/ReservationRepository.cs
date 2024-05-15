using Hotel.Domain.Entities.Reservations;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence.Repositories;

internal sealed class ReservationRepository(ApplicationDbContext context) : IReservationRepository
{
    public async Task CreateAsync(Reservation reservation, CancellationToken cancellationToken)
    {
        await context.Reservations.AddAsync(reservation, cancellationToken);
    }

    public void Delete(Reservation reservation)
    {
        context.Reservations.Remove(reservation);
    }

    public async Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Reservations.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Reservation>> GetAsync(CancellationToken cancellationToken)
    {
        return await context.Reservations.ToListAsync(cancellationToken);
    }
}