using System.Diagnostics;
using System.Net;

namespace Hotel.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        { 
            await next(context);
        }
        catch (Exception exception)
        {
            string? message;
            int statusCode;
            string section;

            switch (exception)
            {
                default: 
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    section = "15.6.1.";
                    message = exception.Message;
                    logger.LogError(exception, "Возникла ошибка при обработке запроса");
                    break;
            }
            context.Response.StatusCode = statusCode;
            var errorResponse = new
            {
                errors = new { Error = message },
                type = $"https://tools.ietf.org/html/rfc9110#section-{section}",
                title = "One or more errors occurred.",
                status = context.Response.StatusCode,
                traceId = Activity.Current?.Id ?? context.TraceIdentifier
            };
            
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}