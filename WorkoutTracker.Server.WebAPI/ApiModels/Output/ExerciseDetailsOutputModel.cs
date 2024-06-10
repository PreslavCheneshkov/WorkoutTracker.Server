namespace WorkoutTracker.Server.WebAPI.ApiModels.Output;

public class ExerciseDetailsOutputModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public IEnumerable<ExerciseParameterDetailsOutputModel> Parameters { get; set; } = new List<ExerciseParameterDetailsOutputModel>();
}
