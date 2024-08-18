using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandlerException(context, e);
        }
    }

    private async Task HandlerException(HttpContext context, Exception e)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,            
            Title = "Server failure"
        };

        response.StatusCode = problemDetails.Status.Value;

        var message = $"Error {e.Message}, innerException: {e.InnerException}, servicesName: {e.TargetSite.ReflectedType.FullName}.{e.TargetSite.Name}";
        _logger.LogError(message);
                
        await response.WriteAsJsonAsync(problemDetails);
    }

}
