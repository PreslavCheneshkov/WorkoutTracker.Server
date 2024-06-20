using WorkoutTracker.Server.Core.ServiceModels.User;

namespace WorkoutTracker.Server.Core.Services.Contracts;

public interface IUserService
{
    Task<bool> SetUsernameAsync(string username, string userId);

    Task<string?> GetUsernameAsync(string userId);

    Task SetPersonalStats(double? weightKilograms, double? bodyFatPercentage, string userId);

    Task<PersonalStatsServiceModel> GetPersonalStatsAsync(string userId);

    Task<IEnumerable<WeightHistoryDataPointServiceModel>> GetWeightHistory(string userId);

    Task<IEnumerable<BodyfatHistoryDataPointServiceModel>> GetBodyfatPercentageHistory(string userId);
}
