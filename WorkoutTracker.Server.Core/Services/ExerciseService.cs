using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Server.Core.ServiceModels.Exercise;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data;
using WorkoutTracker.Server.Data.Entities.Exercise;

namespace WorkoutTracker.Server.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly WorkoutTrackerDbContext _db;

        public ExerciseService(WorkoutTrackerDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddExerciseAsync(ExerciseServiceModel exerciseInput)
        {
            var exercise = new Exercise()
            {
                TrainingSessionId = exerciseInput.TrainingSessionId,
                ExerciseNameId = exerciseInput.ExerciseNameId,
            };
            await _db.Exercises.AddAsync(exercise);
            await _db.SaveChangesAsync();

            var exerciseParameters = exerciseInput.ExerciseParameters.Select(ep => new ExerciseParameter
            {
                ExerciseId = exercise.Id,
                ExerciseParameterNameId = ep.NameId,
                Value = ep.Value
            }).ToList();

            await _db.ExerciseParameters.AddRangeAsync(exerciseParameters);
            await _db.SaveChangesAsync();

            return exercise.Id;
        }

        public async Task<int> AddExerciseNameAsync(string exerciseNameValue)
        {
            var exerciseName = new ExerciseName
            {
                Value = exerciseNameValue
            };
            await _db.ExerciseNames.AddAsync(exerciseName);
            await _db.SaveChangesAsync();
            return exerciseName.Id;
        }

        public async Task AddExerciseParameterNameAsync(string exerciseParameterNameValue)
        {
            var exerciseParameterName = new ExerciseParameterName()
            {
                Value = exerciseParameterNameValue
            };
            _db.ExerciseParameterNames.Add(exerciseParameterName);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ExerciseNameServiceModel>> GetAllExerciseNamesAsync()
        {
            return await _db.ExerciseNames.Where(x => !x.IsDeleted).Select(x => new ExerciseNameServiceModel
            {
                Id = x.Id,
                Value = x.Value
            }).ToListAsync();
        }

        public async Task<IList<ExerciseParameterNameServiceModel>> GetExerciseParameterNamesAsync()
        {
            return await _db.ExerciseParameterNames.Where(x => !x.IsDeleted).Select(x => new ExerciseParameterNameServiceModel
            {
                Id = x.Id,
                Value = x.Value
            }).ToListAsync();
        }
    }
}
