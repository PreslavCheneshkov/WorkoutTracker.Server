using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutTracker.Server.Data.Common;
using WorkoutTracker.Server.Data.Entities.User;

namespace WorkoutTracker.Server.Data.Entities.Training
{
    public class TrainingSession : ISoftDeletable
    {
        [Key]
        public int Id { get; set; }

        public DateTime Started { get; set; }

        [Required]
        public bool IsFinished { get; set; }

        public long? DurationTicks { get; set; }

        [Required]
        [ForeignKey(nameof(WorkoutTrackerUser))]
        public string WorkoutTrackerUserId { get; set; } = null!;

        public virtual WorkoutTrackerUser WorkoutTrackerUser { get; set; } = null!;

        public ICollection<Exercise.Exercise> Exercises { get; set; } = new List<Exercise.Exercise>();

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
