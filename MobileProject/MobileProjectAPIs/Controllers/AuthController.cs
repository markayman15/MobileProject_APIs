using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileProjectAPIs.Core.DTOs;
using MobileProjectAPIs.Core.Entities;

namespace MobileProjectAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> SignUp(SignUpDTO signUpDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(signUpDTO.email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "User already exists" });
            }

            var user = new AppUser
            {
                Name = signUpDTO.name,
                Email = signUpDTO.email,
                Gender = signUpDTO.gender,
            };

            if (signUpDTO.level.HasValue)
            {
                user.Level = signUpDTO.level.Value;
            }

            var result = await _userManager.CreateAsync(user, signUpDTO.password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Account Created");
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult> LogIn(LogInDTO model)
        {
            var check = await _userManager.FindByEmailAsync(model.email);
            if (check == null)
            {
                return BadRequest("No Account With This Email");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(check, model.password, false);

            if (result.Succeeded is false)
            {
                return Unauthorized();
            }

            return Ok("Success logIn");
        }
    }
}
