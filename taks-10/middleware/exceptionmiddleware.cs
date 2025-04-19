public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // move to the next middleware/component
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred."); // log the error
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                Message = "Something went wrong. Please try again later.",
                Error = ex.Message
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
