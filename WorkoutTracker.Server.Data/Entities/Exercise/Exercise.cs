using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutTracker.Server.Data.Common;
using WorkoutTracker.Server.Data.Entities.Training;

namespace WorkoutTracker.Server.Data.Entities.Exercise
{
    public class Exercise : ISoftDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(ExerciseName))]
        public int ExerciseNameId { get; set; }

        [Required]
        [ForeignKey(nameof(TrainingSession))]
        public int TrainingSessionId { get; set; }

        public TrainingSession TrainingSession { get; set; } = null!;

        public ICollection<ExerciseParameter> ExerciseParameters { get; set; } = new List<ExerciseParameter>();

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
