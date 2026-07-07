using Microsoft.AspNetCore.Identity;
using task21.context;
using task21.Models;

namespace task21.Shared.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
         // add identity core not add identity because identity use usually in mvc and make 404 on api
            services.AddIdentityCore<AppUser>(options =>
            {
               
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
            })
            .AddRoles<IdentityRole>() 
            .AddEntityFrameworkStores<FinalJwtContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
