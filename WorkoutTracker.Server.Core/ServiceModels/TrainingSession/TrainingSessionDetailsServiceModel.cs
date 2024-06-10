using WorkoutTracker.Server.Core.ServiceModels.Exercise;

namespace WorkoutTracker.Server.Core.ServiceModels.TrainingSession;

public class TrainingSessionDetailsServiceModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Comment { get; set; }

    public TimeSpan? Duration { get; set; }

    public DateTime Started { get; set; }

    public bool IsFinished { get; set; }

    public IEnumerable<ExerciseDetailsServiceModel> Exercises { get; set; } = new List<ExerciseDetailsServiceModel>();
}
