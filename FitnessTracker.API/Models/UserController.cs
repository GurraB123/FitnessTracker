using System.Threading.Tasks;
using FitnessTracker.API.Models;
using FitnessTracker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            var result = await _userService.RegisterUser(user);
            if (result)
                return Ok("User registered successfully");
            return BadRequest("Registration failed");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var token = await _userService.LoginUser(email, password);
            if (token != null)
                return Ok(new { Token = token });
            return Unauthorized("Invalid credentials");
        }
    }
}
