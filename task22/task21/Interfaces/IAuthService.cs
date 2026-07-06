using Microsoft.AspNetCore.Identity;
using task21.DTO;

namespace task21.Interfaces
{
    public interface IAuthService
    {
         Task<AuthResponseDto?> LoginAsync(LoginDto dto);
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto?> RefreshTokenAsync(TokenRequestDto dto);
        Task<bool> LogoutAsync(string refreshToken);
    }
}
