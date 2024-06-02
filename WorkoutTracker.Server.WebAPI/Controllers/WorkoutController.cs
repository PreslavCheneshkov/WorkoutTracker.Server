using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Server.Core.Services;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data.Entities.User;
using WorkoutTracker.Server.WebAPI.ApiModels;
using WorkoutTracker.Server.WebAPI.ApiModels.Output;

namespace WorkoutTracker.Server.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : WorkoutTrackerController
    {
        private readonly UserManager<WorkoutTrackerUser> _userManager;
        private readonly ITrainingSessionService _trainingSessionService;

        public WorkoutController(UserManager<WorkoutTrackerUser> userManager, ITrainingSessionService trainingSessionService)
        {
            _userManager = userManager;
            _trainingSessionService = trainingSessionService;
        }

        [HttpPost]
        [Route("workout/start")]
        public async Task<IActionResult> Start()
        {
            var userId = _userManager.Users.First(u => u.UserName == User!.Identity!.Name!).Id;
            var workoutId = await _trainingSessionService.StartTrainingSession(userId);
            return Ok(new StartWorkoutResult
            {
                WorkoutId = workoutId
            });
        }

        [HttpPost]
        [Route("workout/end")]
        public async Task<IActionResult> End(int workoutId)
        {
            await _trainingSessionService.EndTrainingSession(workoutId);
            return Ok();
        }
    }
}
