using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data.Entities.User;
using WorkoutTracker.Server.WebAPI.ApiModels.Output;

namespace WorkoutTracker.Server.WebAPI.Controllers;

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
    [Route("Start/{name}")]
    public async Task<IActionResult> Start(string? name)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return Unauthorized();
        }
        var workoutId = await _trainingSessionService.StartTrainingSession(userId, name);
        return Ok(new StartWorkoutResult
        {
            WorkoutId = workoutId
        });
    }

    [HttpPost]
    [Route("End")]
    public async Task<IActionResult> End(int workoutId, [FromBody] string? comment)
    {
        var duration = await _trainingSessionService.EndTrainingSession(workoutId, comment);
        return Ok(new WorkoutDurationOutput
        {
            Days = duration.Days,
            Hours = duration.Hours,
            Minutes = duration.Minutes,
            Seconds = duration.Seconds
        });
    }

    [HttpGet]
    [Route("HasActive")]
    public async Task<IActionResult> HasActiveWorkout()
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return Unauthorized();
        }
        var activeWorkout = await _trainingSessionService.HasActiveTrainingSession(userId);
        if (activeWorkout is null)
        {
            return NotFound();
        }
        if (!activeWorkout.HasActiveTrainingSesion || activeWorkout.TrainingSession is null)
        {
            return Ok(new HasActiveWorkoutOutputModel
            {
                HasActiveWorkout = false,
                Workout = null
            });
        }
        return Ok(new HasActiveWorkoutOutputModel
        {
            HasActiveWorkout = activeWorkout.HasActiveTrainingSesion,
            Workout = new TrainingSessionDetailsOutputModel(activeWorkout.TrainingSession)
        });
    }

    [HttpGet]
    [Route("Details/{workoutId}")]
    public async Task<IActionResult> Details(int workoutId)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return Unauthorized();
        }
        // todo: check if the workout is of the same user
        var trainingSession = await _trainingSessionService.GetTrainingSessionDetailsAsync(workoutId);
        if (trainingSession is null)
        {
            return NotFound();
        }

        return Ok(new TrainingSessionDetailsOutputModel(trainingSession));
    }

    [HttpGet]
    [Route("MyWorkouts")]
    public async Task<IActionResult> MyWorkouts()
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return Unauthorized();
        }
        var workouts = await _trainingSessionService.GetWorkoutsForUser(userId);
        if (workouts is null)
        {
            return NotFound();
        }
        if (!workouts.Any())
        {
            return NoContent();
        }
        return Ok(workouts.Select(w => new WorkoutListOutputModel(w)));
    }
}
