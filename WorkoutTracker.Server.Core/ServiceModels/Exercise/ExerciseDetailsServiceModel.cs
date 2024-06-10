namespace WorkoutTracker.Server.Core.ServiceModels.Exercise;

public class ExerciseDetailsServiceModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public IEnumerable<ExerciseParameterDetailsServiceModel> Parameters { get; set; } = new List<ExerciseParameterDetailsServiceModel>();
}
