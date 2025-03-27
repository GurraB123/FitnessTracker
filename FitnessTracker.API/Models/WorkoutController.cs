using System.Threading.Tasks;
using FitnessTracker.API.Models;
using FitnessTracker.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutService _workoutService;

        public WorkoutController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost]
        public async Task<IActionResult> LogWorkout(Workout workout)
        {
            var result = await _workoutService.LogWorkout(workout);
            if (result)
                return Ok("Workout logged successfully");
            return BadRequest("Failed to log workout");
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetWorkoutHistory()
        {
            var userId = GetUserIdFromToken();
            var history = await _workoutService.GetWorkoutHistory(userId);
            return Ok(history);
        }

        private int GetUserIdFromToken()
        {
            // Implementation to extract user ID from the token
            // This is a placeholder and should be implemented properly
            return 0;
        }
    }
}
