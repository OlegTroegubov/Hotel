namespace Hotel.Domain.Entities.Rooms;

public interface IRoomRepository
{
    Task CreateAsync(Room room, CancellationToken cancellationToken);
    void Delete(Room room);
    Task<Room?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Room>> GetAsync(CancellationToken cancellationToken);
}