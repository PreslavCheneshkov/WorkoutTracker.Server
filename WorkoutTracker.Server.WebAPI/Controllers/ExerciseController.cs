using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        [Route("exercise/parameter/name/{parameterNameValue}")]
        public async Task<IActionResult> ExerciseParameterName(string parameterNameValue)
        {
            if (string.IsNullOrEmpty(parameterNameValue))
            {
                return BadRequest();
            }

            await _exerciseService.AddExerciseParameterName(parameterNameValue);
            return Ok();
        }

        [HttpGet]
        [Route("exercise/parameter/name/all")]
        public async Task<IActionResult> ExerciseParameterName()
        {
            var exerciseParameterNames = await _exerciseService.GetExerciseParameterNames();
            return Ok(exerciseParameterNames);
        }

        [HttpPost]
        [Route("exercise/name/{nameValue}")]
        public async Task<IActionResult> ExerciseName(string nameValue)
        {
            if (string.IsNullOrEmpty(nameValue))
            {
                return BadRequest();
            }

            var id = await _exerciseService.AddExerciseName(nameValue);
            return Ok(id);
        }

        [HttpPost]
        [Route("exercise")]
        public async Task<IActionResult> AddExercise(ExerciseInputModel exerciseInput)
        {
            var id = await _exerciseService.AddExercise(new Core.ServiceModels.ExerciseServiceModel
            {
                ExerciseNameId = exerciseInput.ExerciseNameId,
                TrainingSessionId = exerciseInput.TrainingSessionId,
                ExerciseParameters = exerciseInput.ExerciseParameters.Select(x => new Core.ServiceModels.ExerciseParameterServiceModel
                {
                    NameId = x.NameId,
                    Value = x.Value
                }).ToList()
            });
            return Ok(id);
        }
    }
}
