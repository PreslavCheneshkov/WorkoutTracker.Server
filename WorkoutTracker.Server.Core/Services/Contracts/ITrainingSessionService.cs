using WorkoutTracker.Server.Core.ServiceModels.TrainingSession;

namespace WorkoutTracker.Server.Core.Services.Contracts;

public interface ITrainingSessionService
{
    Task<int> StartTrainingSession(string userId, string? name);

    Task<TimeSpan> EndTrainingSession(int id, string? comment);

    Task<HasActiveTrainingSesionServiceModel> HasActiveTrainingSession(string userId);

    Task<TrainingSessionDetailsServiceModel?> GetTrainingSessionDetailsAsync(int trainingSessionId);
}
