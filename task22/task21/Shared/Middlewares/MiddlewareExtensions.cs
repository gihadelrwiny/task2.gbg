using task21.Shared.Middlewares;

namespace task21.Helpers.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler();

            return app;
        }
        //new middle ware for this task
        public static IApplicationBuilder UseRequestTiming(
        this IApplicationBuilder app) =>
         app.UseMiddleware<RequestTimingMiddleware>();

        public static IApplicationBuilder UseRateLimiting(
            this IApplicationBuilder app)=>
              app.UseMiddleware<RateLimitingMiddleware>();
    }
}
