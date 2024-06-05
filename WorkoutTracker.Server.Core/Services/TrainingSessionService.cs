using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data;
using WorkoutTracker.Server.Data.Entities.Training;

namespace WorkoutTracker.Server.Core.Services
{
    public class TrainingSessionService : ITrainingSessionService
    {
        private readonly WorkoutTrackerDbContext _db;

        public TrainingSessionService(WorkoutTrackerDbContext db)
        {
            _db = db;
        }

        public async Task<int> StartTrainingSession(string userId)
        {
            var session = new TrainingSession()
            {
                Started = DateTime.UtcNow,
                WorkoutTrackerUserId = userId
            };
            await _db.TrainingSessions.AddAsync(session);
            await _db.SaveChangesAsync();
            return session.Id;
        }

        public async Task<TimeSpan> EndTrainingSession(int id)
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

            await _db.SaveChangesAsync();
            return duration;
        }

        public async Task<bool> HasActiveTrainingSession(string userId)
        {
            return await _db.TrainingSessions.AnyAsync(x => x.WorkoutTrackerUserId == userId && !x.IsFinished);
        }
    }
}
