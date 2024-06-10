namespace WorkoutTracker.Server.Core.ServiceModels.Exercise;

public class ExerciseParameterDetailsServiceModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Value { get; set; }
}
