using Hotel.Application.Common.Interfaces;
using Hotel.Domain.Entities.Amenities;
using Hotel.Domain.Entities.Reservations;
using Hotel.Domain.Entities.Rooms;
using Hotel.Domain.Entities.Visitor;
using Hotel.Infrastructure.Persistence;
using Hotel.Infrastructure.Persistence.Interceptors;
using Hotel.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<SaveEntitiesInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, opt)
            =>
        {
            var saveEntitiesInterceptor = sp.GetRequiredService<SaveEntitiesInterceptor>();

            opt.UseNpgsql(configuration.GetConnectionString("Database"),
                    builder => builder
                        .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .AddInterceptors(saveEntitiesInterceptor);
        });

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IAmenityRepository, AmenityRepository>();

        services.AddScoped<IReservationRepository, ReservationRepository>();

        services.AddScoped<IRoomRepository, RoomRepository>();

        services.AddScoped<IVisitorRepository, VisitorRepository>();

        services.AddScoped<ApplicationDbContextInitializer>();
    }
}