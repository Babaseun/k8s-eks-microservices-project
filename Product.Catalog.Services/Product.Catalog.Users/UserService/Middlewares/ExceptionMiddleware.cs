using System.Net;
using System.Text.Json;
using UserService.Exceptions;

namespace UserService.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        int statusCode;
        string message;

        if (exception is ApiException apiException)
        {
            // Handle custom API exceptions
            statusCode = apiException.StatusCode;
            message = apiException.Message;
        }
        else
        {
            // Handle unknown exceptions
            statusCode = (int)HttpStatusCode.InternalServerError;
            message = "An unexpected error occurred.";
        }

        context.Response.StatusCode = statusCode;

        var response = new
        {
            StatusCode = statusCode,
            Message = message,
            Detailed = exception.Message // For logging purposes
        };

        var jsonResponse = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(jsonResponse);
    }
}