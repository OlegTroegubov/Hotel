using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddAutoMapper(config =>
            config.AddMaps(Assembly.GetExecutingAssembly()));
    }
}