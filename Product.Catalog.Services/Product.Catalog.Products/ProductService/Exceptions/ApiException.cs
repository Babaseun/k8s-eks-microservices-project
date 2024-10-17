namespace ProductService.Middlewares;

public class ApiException : Exception
{
    public int StatusCode { get; }

    public ApiException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}

public class BadRequestException : ApiException
{
    public BadRequestException(string message = "Bad Request")
        : base(message, StatusCodes.Status400BadRequest)
    {
    }
}

public class UnauthorizedException : ApiException
{
    public UnauthorizedException(string message = "Unauthorized")
        : base(message, StatusCodes.Status401Unauthorized)
    {
    }
}

public class NotFoundException : ApiException
{
    public NotFoundException(string message = "Resource not found")
        : base(message, StatusCodes.Status404NotFound)
    {
    }
}
