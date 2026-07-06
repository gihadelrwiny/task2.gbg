using task21.Models;

namespace task21.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(AppUser user, IList<string> roles);
        string GenerateRefreshToken();

    }
}
