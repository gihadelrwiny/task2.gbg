using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task21.Helpers.Exceptions;

namespace task21.Helpers.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
           httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                ConflictException => StatusCodes.Status409Conflict,
                ValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
          await httpContext.Response.WriteAsJsonAsync(
           new ProblemDetails
                {
                    Title = exception switch
                    {
                        NotFoundException => "Not Found",
                        ConflictException => "Conflict",
                        ValidationException => "Validation Error",
                        _ => "Server Error"
                    },

                    Status = httpContext.Response.StatusCode,

                    Detail = exception.Message,

                    Instance = httpContext.Request.Path
                },
                cancellationToken);
            return true;
        }
    }
}
