namespace WorkoutTracker.Server.Core.ServiceModels.Exercise;

public class ExerciseStatServiceModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ExerciseNameId { get; set; }

    public int TrainingSessionId { get; set; }

    public DateTime DateTime { get; set; }

    public IEnumerable<ExerciseStatParameterServiceModel> Parameters { get; set; } = new List<ExerciseStatParameterServiceModel>();
}
