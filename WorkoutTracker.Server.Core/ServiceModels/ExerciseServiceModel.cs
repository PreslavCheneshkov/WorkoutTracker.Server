namespace WorkoutTracker.Server.Core.ServiceModels
{
    public class ExerciseServiceModel
    {
        public int TrainingSessionId { get; set; }

        public int ExerciseNameId { get; set; }

        public List<ExerciseParameterServiceModel> ExerciseParameters { get; set; } = new List<ExerciseParameterServiceModel>();
    }
}
