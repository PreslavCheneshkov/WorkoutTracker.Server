using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutTracker.Server.Data.Entities.User;

namespace WorkoutTracker.Server.Data.Entities.Training
{
    public class TrainingSession
    {
        [Key]
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        [Required]
        [ForeignKey(nameof(WorkoutTrackerUser))]
        public string WorkoutTrackerUserId { get; set; } = null!;

        public WorkoutTrackerUser WorkoutTrackerUser { get; set; } = null!;

        public ICollection<Exercise.Exercise> Exercises { get; set; } = new List<Exercise.Exercise>();
    }
}
