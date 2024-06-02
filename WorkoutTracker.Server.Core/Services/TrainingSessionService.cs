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
                DateTime = DateTime.UtcNow,
                WorkoutTrackerUserId = userId
            };
            await _db.TrainingSessions.AddAsync(session);
            await _db.SaveChangesAsync();
            return session.Id;
        }

        public async Task EndTrainingSession(int id)
        {
            var session = await _db.TrainingSessions.FirstOrDefaultAsync(ts => ts.Id == id);
            if (session is null)
            {
                // todo: Add exception handling
            }
            session!.IsFinished = true;
            await _db.SaveChangesAsync();
        }
    }
}
