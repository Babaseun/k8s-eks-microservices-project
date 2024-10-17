namespace UserService.Exceptions;

public class ApiException(string message, int statusCode) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}

public class BadRequestException(string message = "Bad Request") : ApiException(message, StatusCodes.Status400BadRequest);

public class UnauthorizedException(string message = "Unauthorized")
    : ApiException(message, StatusCodes.Status401Unauthorized);

public class NotFoundException(string message = "Resource not found")
    : ApiException(message, StatusCodes.Status404NotFound);
