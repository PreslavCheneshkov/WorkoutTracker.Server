using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Server.Core.ServiceModels.Exercise;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data.Entities.User;
using WorkoutTracker.Server.WebAPI.ApiModels.Input;

namespace WorkoutTracker.Server.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : WorkoutTrackerController
    {
        private readonly IExerciseService _exerciseService;
        private readonly UserManager<WorkoutTrackerUser> _userManager;

        public ExerciseController(IExerciseService exerciseService, UserManager<WorkoutTrackerUser> userManager)
        {
            _exerciseService = exerciseService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("parameter/name/{parameterNameValue}")]
        public async Task<IActionResult> ExerciseParameterName(string parameterNameValue)
        {
            if (string.IsNullOrEmpty(parameterNameValue))
            {
                return BadRequest();
            }

            await _exerciseService.AddExerciseParameterNameAsync(parameterNameValue);
            return Ok();
        }

        [HttpGet]
        [Route("parameter/name/all")]
        public async Task<IActionResult> ExerciseParameterName()
        {
            var exerciseParameterNames = await _exerciseService.GetExerciseParameterNamesAsync();
            return Ok(exerciseParameterNames);
        }

        [HttpGet]
        [Route("name")]
        public async Task<IActionResult> ExercisNames()
        {
            var exerciseNames = await _exerciseService.GetAllExerciseNamesAsync();
            return Ok(exerciseNames);
        }

        [HttpPost]
        [Route("name/{nameValue}")]
        public async Task<IActionResult> ExerciseName(string nameValue)
        {
            if (string.IsNullOrEmpty(nameValue))
            {
                return BadRequest();
            }

            var id = await _exerciseService.AddExerciseNameAsync(nameValue);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(ExerciseInputModel exerciseInput)
        {
            var id = await _exerciseService.AddExerciseAsync(new ExerciseServiceModel
            {
                ExerciseNameId = exerciseInput.ExerciseNameId,
                TrainingSessionId = exerciseInput.TrainingSessionId,
                ExerciseParameters = exerciseInput.ExerciseParameters.Select(x => new ExerciseParameterServiceModel
                {
                    NameId = x.NameId,
                    Value = x.Value
                }).ToList()
            });
            return Ok(id);
        }
    }
}
