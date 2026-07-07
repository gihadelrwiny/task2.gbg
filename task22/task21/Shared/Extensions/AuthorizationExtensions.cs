using task21.Models;

namespace task21.Shared.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanDeleteUsers", policy =>
                {
                    policy.RequireRole("Admin");
                });
                options.AddPolicy("PremiumFeature", policy =>
                {
                    policy.RequireClaim("SubscriptionLevel", "Premium");
                });
                options.AddPolicy("SeniorOnly", policy =>
                {
                    policy.Requirements.Add(new MinExperienceRequirement(5));
                });
                options.AddPolicy("EditProfile", policy =>
                {
                    policy.Requirements.Add(new UserProfileRequirement());
                });




            });
            return services;

        }
    }
}
