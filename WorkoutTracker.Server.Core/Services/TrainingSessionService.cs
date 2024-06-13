using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Server.Core.ServiceModels.Exercise;
using WorkoutTracker.Server.Core.ServiceModels.TrainingSession;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data;
using WorkoutTracker.Server.Data.Entities.Training;

namespace WorkoutTracker.Server.Core.Services;

public class TrainingSessionService : ITrainingSessionService
{
    private readonly WorkoutTrackerDbContext _db;

    public TrainingSessionService(WorkoutTrackerDbContext db)
    {
        _db = db;
    }

    public async Task<int> StartTrainingSession(string userId, string? name)
    {
        var session = new TrainingSession()
        {
            Name = name,
            Started = DateTime.UtcNow,
            WorkoutTrackerUserId = userId
        };
        await _db.TrainingSessions.AddAsync(session);
        await _db.SaveChangesAsync();
        return session.Id;
    }

    public async Task<TimeSpan> EndTrainingSession(int id, string? comment)
    {
        var session = await _db.TrainingSessions.FirstOrDefaultAsync(ts => ts.Id == id);
        if (session is null)
        {
            // todo: Add exception handling
        }
        if (session.IsFinished)
        {
            // todo: exception handling
        }
        var duration = DateTime.UtcNow - session.Started;
        session!.IsFinished = true;
        session.DurationTicks = duration.Ticks;
        session.Comment = comment;

        await _db.SaveChangesAsync();
        return duration;
    }

    public async Task<HasActiveTrainingSesionServiceModel> HasActiveTrainingSession(string userId)
    {
        var activeTrainingSession = await _db.TrainingSessions.Where(x => x.WorkoutTrackerUserId == userId && !x.IsFinished).Select(ts => new TrainingSessionDetailsServiceModel
        {
            Id = ts.Id,
            Comment = ts.Comment,
            Name = ts.Name,
            Started = ts.Started,
            IsFinished = ts.IsFinished,
            Duration = TimeSpan.FromTicks(ts.DurationTicks ?? 0),
            Exercises = ts.Exercises.Select(e => new ExerciseDetailsServiceModel
            {
                Id = e.Id,
                Name = e.ExerciseName.Value,
                Parameters = e.ExerciseParameters.Select(ep => new ExerciseParameterDetailsServiceModel
                {
                    Id = ep.Id,
                    Name = ep.ExerciseParameterName.Value,
                    Value = ep.Value
                })
            })
        }).FirstOrDefaultAsync();
        var hasActiveTrainingSession = activeTrainingSession != null;
        if (activeTrainingSession != null)
        {
            activeTrainingSession.Duration = DateTime.UtcNow - activeTrainingSession.Started;
        }
        return new HasActiveTrainingSesionServiceModel
        {
            HasActiveTrainingSesion = hasActiveTrainingSession,
            TrainingSession = activeTrainingSession
        };
    }

    public async Task<TrainingSessionDetailsServiceModel?> GetTrainingSessionDetailsAsync(int trainingSessionId)
    {
        var trainingSession =  await _db.TrainingSessions.Where(ts => ts.Id == trainingSessionId)
                                         .Select(ts => new TrainingSessionDetailsServiceModel
                                         {
                                             Id = ts.Id,
                                             Comment = ts.Comment,
                                             Name = ts.Name,
                                             Started = ts.Started,
                                             IsFinished = ts.IsFinished,
                                             Duration = TimeSpan.FromTicks(ts.DurationTicks ?? 0),
                                             Exercises = ts.Exercises.Select(e => new ExerciseDetailsServiceModel
                                             {
                                                 Id = e.Id,
                                                 Name = e.ExerciseName.Value,
                                                 Parameters = e.ExerciseParameters.Select(ep => new ExerciseParameterDetailsServiceModel
                                                 {
                                                     Id = ep.Id,
                                                     Name = ep.ExerciseParameterName.Value,
                                                     Value = ep.Value
                                                 })
                                             })
                                         }).FirstOrDefaultAsync();
        if (trainingSession is null)
        {
            return null;
        }
        if (!trainingSession.IsFinished)
        {
            trainingSession.Duration = DateTime.UtcNow - trainingSession.Started;
        }
        return trainingSession;
    }

    public async Task<IEnumerable<WorkoutListServiceModel>> GetWorkoutsForUser(string userId)
    {
        return await _db.TrainingSessions.Where(w => w.WorkoutTrackerUserId == userId).Select(w => new WorkoutListServiceModel
        {
            Id = w.Id,
            IsFinished = w.IsFinished,
            Name = w.Name,
            Started = w.Started,
        }).ToListAsync();
    }
}
