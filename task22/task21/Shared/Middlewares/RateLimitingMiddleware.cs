using System.Collections.Concurrent;

namespace task21.Shared.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;

        private static readonly ConcurrentDictionary<string,(int Count, DateTime Window)> _requests = new();

        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var now = DateTime.Now;
            if(_requests.TryGetValue(ip,out var entry))
            {
                if ((now - entry.Window).TotalMinutes >= 1)
                {
                    entry = (1, now);
                }
                else
                {
                    entry.Count ++;
                    if (entry.Count > 10)
                    {
                        context.Response.StatusCode = 429;
                        await context.Response.WriteAsync("Too Many Requests");
                        return;
                    }
                   
                }
                _requests[ip] = entry;
            }
            else
            {      
              _requests[ip]= (1, now);
            }
            await _next(context);
        }
    }
}
