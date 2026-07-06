using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using task21.context;
using task21.DTO;
using task21.Interfaces;
using task21.Models;

namespace task21.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly FinalJwtContext _context;
        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService, FinalJwtContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }
        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return null;

            var validpassword = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!validpassword)
                return null;
            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _tokenService.GenerateAccessToken(user, roles);
            //refresh token
            var refreshTokenString = _tokenService.GenerateRefreshToken();
            var refreshToken = new RefreshToken
            {
                Token = refreshTokenString,
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();
            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenString,
                UserName = user.UserName!,
                Roles = roles.ToList(),
                ExpiresAt = DateTime.UtcNow.AddMinutes(15)
            };

        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email is already registered." });
            }
            var user = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return result;
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
            {
                return roleResult;
            }

            return IdentityResult.Success;
        }
        public async Task<AuthResponseDto?> RefreshTokenAsync(TokenRequestDto dto)
        {
            var storedRefreshToken = await _context.RefreshTokens
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Token == dto.RefreshToken);

            if (storedRefreshToken == null || !storedRefreshToken.IsActive)
                return null;

            var user = storedRefreshToken.User;
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);
            var newAccessToken = _tokenService.GenerateAccessToken(user, roles);
            var newRefreshTokenString = _tokenService.GenerateRefreshToken();

            // Revoke aold one
            storedRefreshToken.IsRevoked = true;

            // save the new one
            var newRefreshToken = new RefreshToken
            {
                Token = newRefreshTokenString,
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };
            _context.RefreshTokens.Add(newRefreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshTokenString,
                UserName = user.UserName!,
                Roles = roles.ToList(),
                ExpiresAt = DateTime.UtcNow.AddMinutes(15)
            };

        }
        // logout by revoked refresh token
        public async Task<bool> LogoutAsync(string refreshToken)
        {
            var storedToken = await _context.RefreshTokens
               .Include(u => u.User)
               .FirstOrDefaultAsync(t => t.Token ==refreshToken);

            if (storedToken == null) return false;
            storedToken.IsRevoked = true;
            _context.SaveChanges();
            return true;
        }
    }
    }
