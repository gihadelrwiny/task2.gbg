using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace task21.Models
{
    public class AppUser: IdentityUser
    {

     public ICollection<RefreshToken> RefreshTokens { get; set; }
            = new List<RefreshToken>();
        public string SubscriptionLevel { get; set; } = "Basic";
        public int yearsExperience { get; set; }

    }
}
