namespace WorkoutTracker.Server.Core.Services.Contracts
{
    public interface ITrainingSessionService
    {
        Task<int> StartTrainingSession(string userId);

        Task EndTrainingSession(int id);
    }
}
