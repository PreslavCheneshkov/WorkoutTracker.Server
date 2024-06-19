namespace WorkoutTracker.Server.Core.ServiceModels.Exercise;

public class ExerciseStatParameterServiceModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NameId { get; set; }

    public double Value { get; set; }
}
