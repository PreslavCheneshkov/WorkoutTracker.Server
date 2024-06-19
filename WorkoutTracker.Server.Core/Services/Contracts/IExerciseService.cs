using WorkoutTracker.Server.Core.ServiceModels.Exercise;

namespace WorkoutTracker.Server.Core.Services.Contracts
{
    public interface IExerciseService
    {
        Task AddExerciseParameterNameAsync(string exerciseParameterNameValue);

        Task<IList<ExerciseParameterNameServiceModel>> GetExerciseParameterNamesAsync();

        Task<int> AddExerciseNameAsync(string exerciseNameValue);

        Task<int> AddExerciseAsync(ExerciseServiceModel exerciseInput);

        Task<List<ExerciseNameServiceModel>> GetAllExerciseNamesAsync();

        Task<IEnumerable<ExerciseStatServiceModel>> GetStatsForExerciseAsync(int exerciseNameId, string userId, DateTime? startDate, DateTime? endDate);
    }
}
