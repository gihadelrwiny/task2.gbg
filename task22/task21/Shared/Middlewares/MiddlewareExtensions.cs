namespace task21.Helpers.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(
           this IApplicationBuilder app)
        {
            app.UseExceptionHandler();

            return app;
        }
    }
}
