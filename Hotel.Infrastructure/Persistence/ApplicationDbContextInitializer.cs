using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence;

public class ApplicationDbContextInitializer(ApplicationDbContext context)
{
    public async Task InitAsync(CancellationToken cancellationToken = default)
    {
        await context.Database.MigrateAsync(cancellationToken);
    }
}