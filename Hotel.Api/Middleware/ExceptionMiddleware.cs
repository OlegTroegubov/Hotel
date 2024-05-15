using System.Net;

namespace Hotel.Middleware;

internal sealed class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = exception.Message;
            logger.LogError(exception, "Возникла ошибка при обработке запроса");

            context.Response.StatusCode = statusCode;
            var errorResponse = new
            {
                errors = new { Error = message },
                title = "One or more errors occurred.",
                status = context.Response.StatusCode
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}