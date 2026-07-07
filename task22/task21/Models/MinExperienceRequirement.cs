using Microsoft.AspNetCore.Authorization;

namespace task21.Models
{
    public class MinExperienceRequirement:IAuthorizationRequirement
    {
        public int MinimumYears { get; }

        public MinExperienceRequirement(int minimumYears)
        {
            MinimumYears = minimumYears;
        }
    }
}
