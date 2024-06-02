namespace WorkoutTracker.Server.WebAPI.ApiModels.Input
{
    public class ExerciseInputModel
    {
        public int TrainingSessionId { get; set; }

        public int ExerciseNameId { get; set; }

        public List<ExerciseParameterInputModel> ExerciseParameters { get; set; } = new List<ExerciseParameterInputModel>();
    }
}
