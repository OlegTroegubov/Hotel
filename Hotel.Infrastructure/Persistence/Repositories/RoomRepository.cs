using Hotel.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence.Repositories;

internal sealed class RoomRepository(ApplicationDbContext context) : IRoomRepository
{
    public async Task CreateAsync(Room room, CancellationToken cancellationToken)
    {
        await context.Rooms.AddAsync(room, cancellationToken);
    }

    public void Delete(Room room)
    {
        context.Rooms.Remove(room);
    }

    public async Task<Room?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Rooms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Room>> GetAsync(CancellationToken cancellationToken)
    {
        return await context.Rooms.ToListAsync(cancellationToken);
    }
}