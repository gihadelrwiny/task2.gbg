using Microsoft.AspNetCore.Authorization;
using task21.Models;

namespace task21.Shared.Handlers
{
    public class MinExperienceHandler: AuthorizationHandler<MinExperienceRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
          MinExperienceRequirement requirement)
        {
            var claim = context.User.FindFirst("yearsExperience");

            if (claim == null)
                return Task.CompletedTask;

            if (int.TryParse(claim.Value, out int years) &&
                years >= requirement.MinimumYears)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }
}
