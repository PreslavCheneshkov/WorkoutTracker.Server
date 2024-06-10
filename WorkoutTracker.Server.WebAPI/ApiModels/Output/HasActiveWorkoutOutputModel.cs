namespace WorkoutTracker.Server.WebAPI.ApiModels.Output;

public class HasActiveWorkoutOutputModel
{
    public bool HasActiveWorkout { get; set; }

    public TrainingSessionDetailsOutputModel? Workout { get; set; }
}
