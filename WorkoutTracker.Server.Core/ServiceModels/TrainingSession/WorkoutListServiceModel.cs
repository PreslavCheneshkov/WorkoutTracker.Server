namespace WorkoutTracker.Server.Core.ServiceModels.TrainingSession
{
    public class WorkoutListServiceModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime Started { get; set; }

        public bool IsFinished { get; set; }
    }
}
