using System.ComponentModel.DataAnnotations;
using WorkoutTracker.Server.Data.Entities.Training;

namespace WorkoutTracker.Server.Data.Entities.Exercise
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<TrainingSession> Sessions { get; set; } = new List<TrainingSession>();

        public ICollection<ExerciseParameter> ExerciseParameters { get; set; } = new List<ExerciseParameter>();
    }
}
