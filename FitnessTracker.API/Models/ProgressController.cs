using System.Threading.Tasks;
using FitnessTracker.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly ProgressService _progressService;

        public ProgressController(ProgressService progressService)
        {
            _progressService = progressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProgress(string exerciseName, string dateRange)
        {
            var userId = GetUserIdFromToken();
            var progress = await _progressService.GetProgress(userId, exerciseName, dateRange);
            return Ok(progress);
        }

        private int GetUserIdFromToken()
        {
            // Implementation to extract user ID from the token
            // This is a placeholder and should be implemented properly
            return 0;
        }
    }
}