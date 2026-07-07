using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using task21.Models;

namespace task21.Shared.Handlers
{
    public class UserProfileHandler
      : AuthorizationHandler<UserProfileRequirement, AppUser>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UserProfileRequirement requirement,
            AppUser resource)
        {
            // if he Admin
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            // current user
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // if editing self
            if (userId == resource.Id)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
