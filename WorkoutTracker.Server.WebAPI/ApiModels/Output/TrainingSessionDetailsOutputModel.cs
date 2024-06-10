namespace WorkoutTracker.Server.WebAPI.ApiModels.Output;

public class TrainingSessionDetailsOutputModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Comment { get; set; }

    public WorkoutDurationOutput Duration { get; set; } = new WorkoutDurationOutput();

    public DateTime Started { get; set; }

    public bool IsFinished { get; set; }

    public IEnumerable<ExerciseDetailsOutputModel> Exercises { get; set; } = new List<ExerciseDetailsOutputModel>();
}
