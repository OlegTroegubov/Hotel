using Hotel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<SaveChangesInterceptor>();
        
        services.AddDbContext<ApplicationDbContext>((serviceProvider, opt)
            =>
        {
            var saveEntitiesInterceptor = serviceProvider.GetService<SaveChangesInterceptor>()!;
            
            opt.UseNpgsql(configuration.GetConnectionString("Database"), 
    builder => builder
                    .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                    .AddInterceptors(saveEntitiesInterceptor);
        });

        services.AddScoped<ApplicationDbContextInitializer>();
    }
}