namespace WorkoutTracker.Server.Core.ServiceModels.TrainingSession;

public class HasActiveTrainingSesionServiceModel
{
    public bool HasActiveTrainingSesion { get; set; }

    public TrainingSessionDetailsServiceModel? TrainingSession { get; set; }
}
