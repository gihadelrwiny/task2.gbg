namespace task21.Shared.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly Dictionary<string, string> _apiKeys = new()
        {
            { "task27-key-123", "PublicClient" },
            { "task27-key-456", "AnotherClient" }
        };

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Apply only to /api/public/*
            if (context.Request.Path.StartsWithSegments("/api/public"))
            {
                if (!context.Request.Headers.TryGetValue("X-Api-Key", out var apiKey))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        message = "API Key is required"
                    });

                    return;
                }

                if (!_apiKeys.ContainsKey(apiKey.ToString()))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        message = "Invalid API Key"
                    });

                    return;
                }
            }

            await _next(context);
        }
    }
}
