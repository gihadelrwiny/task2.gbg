using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using task21.Models;

namespace task21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(
            IAuthorizationService authorizationService,
            UserManager<AppUser> userManager)
        {
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Policy = "SeniorOnly")]
        public IActionResult GetProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

            return Ok(new
            {
                UserId = userId,
                UserName = userName,
                Email = email,
                Roles = roles
            });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(string id, string userName)
        {
        
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();
            
            var result = await _authorizationService.AuthorizeAsync(
                User,
                user,
                "EditProfile");

            if (!result.Succeeded)
                return Forbid();

            user.UserName = userName;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
                return BadRequest(updateResult.Errors);

            return Ok("Profile updated successfully.");
        }
    }
}