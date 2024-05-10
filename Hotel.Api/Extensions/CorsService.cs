namespace Hotel.Extensions;

internal static class CorsService
{
    public static void AddCorsService(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("DefaultPolicy", builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
                builder.SetIsOriginAllowed(_ => true);
            });
        });
    }
}