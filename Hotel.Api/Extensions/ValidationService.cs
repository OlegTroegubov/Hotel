using FluentValidation;
using FluentValidation.AspNetCore;

namespace Hotel.Extensions;

internal static class ValidationService
{
    public static void AddValidationServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
    }
}