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
        var userId = _userManager.Users.First(u => u.UserName == User!.Identity!.Name!).Id;
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
        var userId = _userManager.Users.First(u => u.UserName == User!.Identity!.Name!).Id;
        var activeWorkout = await _trainingSessionService.HasActiveTrainingSession(userId);
        if (activeWorkout is null)
        {
            return NotFound();
        }
        if (!activeWorkout.HasActiveTrainingSesion)
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
            Workout = new TrainingSessionDetailsOutputModel
            {
                Id = activeWorkout.TrainingSession.Id,
                Comment = activeWorkout.TrainingSession.Comment,
                Name = activeWorkout.TrainingSession.Name,
                Started = activeWorkout.TrainingSession.Started,
                IsFinished = activeWorkout.TrainingSession.IsFinished,
                Duration = new WorkoutDurationOutput
                {
                    Days = activeWorkout.TrainingSession.Duration?.Days ?? 0,
                    Hours = activeWorkout.TrainingSession.Duration?.Hours ?? 0,
                    Minutes = activeWorkout.TrainingSession.Duration?.Minutes ?? 0,
                    Seconds = activeWorkout.TrainingSession.Duration?.Seconds ?? 0,
                },
                Exercises = activeWorkout.TrainingSession.Exercises.Select(e => new ExerciseDetailsOutputModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Parameters = e.Parameters.Select(ep => new ExerciseParameterDetailsOutputModel
                    {
                        Name = ep.Name,
                        Value = ep.Value
                    })
                })
            }
        });
    }

    [HttpGet]
    [Route("Details/{workoutId}")]
    public async Task<IActionResult> Details(int workoutId)
    {
        var trainingSession = await _trainingSessionService.GetTrainingSessionDetailsAsync(workoutId);
        if (trainingSession is null)
        {
            return NotFound();
        }

        return Ok(new TrainingSessionDetailsOutputModel
        {
            Id = trainingSession.Id,
            Comment = trainingSession.Comment,
            Name = trainingSession.Name,
            Started = trainingSession.Started,
            IsFinished = trainingSession.IsFinished,
            Duration = new WorkoutDurationOutput
            {
                Days = trainingSession.Duration?.Days ?? 0,
                Hours = trainingSession.Duration?.Hours ?? 0,
                Minutes = trainingSession.Duration?.Minutes ?? 0,
                Seconds = trainingSession.Duration?.Seconds ?? 0,
            },
            Exercises = trainingSession.Exercises.Select(e => new ExerciseDetailsOutputModel
            {
                Id = e.Id,
                Name = e.Name,
                Parameters = e.Parameters.Select(p => new ExerciseParameterDetailsOutputModel
                {
                    Name = p.Name,
                    Value = p.Value
                })
            })
        });
    }
}
