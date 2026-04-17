using Where_Did_I_Leave_It.Domain.Exceptions;

namespace Where_Did_I_Leave_It.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
            => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ItemException ex) 
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var response = new
                {
                    error = "An unexpected error occurred. Please try again later.",
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, ItemException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = exception.Message,
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
