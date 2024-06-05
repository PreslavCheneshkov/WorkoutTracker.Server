namespace WorkoutTracker.Server.Core.Services.Contracts
{
    public interface ITrainingSessionService
    {
        Task<int> StartTrainingSession(string userId);

        Task<TimeSpan> EndTrainingSession(int id);

        Task<bool> HasActiveTrainingSession(string userId);
    }
}
