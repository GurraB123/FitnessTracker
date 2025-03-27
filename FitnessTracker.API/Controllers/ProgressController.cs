using System;
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
        public async Task<IActionResult> GetProgress(int exerciseId, string dateRange)
        {
            var userId = GetUserIdFromToken();
            var endDate = DateTime.UtcNow;
            var startDate = dateRange switch
            {
                "1M" => endDate.AddMonths(-1),
                "3M" => endDate.AddMonths(-3),
                "6M" => endDate.AddMonths(-6),
                "1Y" => endDate.AddYears(-1),
                _ => endDate.AddMonths(-1)
            };

            var progress = await _progressService.GetProgress(userId, exerciseId, startDate, endDate);
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
