using WorkoutTracker.Server.Core.ServiceModels.TrainingSession;

namespace WorkoutTracker.Server.WebAPI.ApiModels.Output
{
    public class WorkoutListOutputModel
    {
        public WorkoutListOutputModel(WorkoutListServiceModel serviceModel)
        {
            Id = serviceModel.Id;
            Name = serviceModel.Name;
            Started = serviceModel.Started;
            IsFinished = serviceModel.IsFinished;
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime Started { get; set; }

        public bool IsFinished { get; set; }
    }
}
