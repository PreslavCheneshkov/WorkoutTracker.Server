using WorkoutTracker.Server.Core.ServiceModels;

namespace WorkoutTracker.Server.Core.Services.Contracts
{
    public interface IExerciseService
    {
        Task AddExerciseParameterName(string exerciseParameterNameValue);

        Task<IList<ExerciseParameterNameServiceModel>> GetExerciseParameterNames();

        Task<int> AddExerciseName(string exerciseNameValue);

        Task<int> AddExercise(ExerciseServiceModel exerciseInput);
    }
}
