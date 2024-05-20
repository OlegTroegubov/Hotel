namespace Hotel.Domain.Entities.Reservations;

public interface IReservationRepository
{
    Task CreateAsync(Reservation reservation, CancellationToken cancellationToken);
    void Delete(Reservation reservation);
    Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Reservation>> GetAllAsync(CancellationToken cancellationToken);
}