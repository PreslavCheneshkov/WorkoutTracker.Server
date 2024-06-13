using WorkoutTracker.Server.Core.ServiceModels.TrainingSession;

namespace WorkoutTracker.Server.WebAPI.ApiModels.Output;

public class TrainingSessionDetailsOutputModel
{
    public TrainingSessionDetailsOutputModel(TrainingSessionDetailsServiceModel serviceModel)
    {
        Id = serviceModel.Id;
        Comment = serviceModel.Comment;
        Name = serviceModel.Name;
        Started = serviceModel.Started;
        IsFinished = serviceModel.IsFinished;
        Duration = new WorkoutDurationOutput
        {
            Days = serviceModel.Duration?.Days ?? 0,
            Hours = serviceModel.Duration?.Hours ?? 0,
            Minutes = serviceModel.Duration?.Minutes ?? 0,
            Seconds = serviceModel.Duration?.Seconds ?? 0,
        };
        Exercises = serviceModel.Exercises.Select(e => new ExerciseDetailsOutputModel
        {
            Id = e.Id,
            Name = e.Name,
            Parameters = e.Parameters.Select(p => new ExerciseParameterDetailsOutputModel
            {
                Name = p.Name,
                Value = p.Value
            })
        });
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Comment { get; set; }

    public WorkoutDurationOutput Duration { get; set; } = new WorkoutDurationOutput();

    public DateTime Started { get; set; }

    public bool IsFinished { get; set; }

    public IEnumerable<ExerciseDetailsOutputModel> Exercises { get; set; } = new List<ExerciseDetailsOutputModel>();
}
