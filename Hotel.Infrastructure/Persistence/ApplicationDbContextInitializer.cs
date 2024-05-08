using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task InitAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.MigrateAsync(cancellationToken);
    }
}