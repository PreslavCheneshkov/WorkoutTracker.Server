using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutTracker.Server.Data.Common;

namespace WorkoutTracker.Server.Data.Entities.Exercise
{
    public class ExerciseParameter : ISoftDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(ExerciseParameterName))]
        public int ExerciseParameterNameId { get; set; }

        public ExerciseParameterName ExerciseParameterName { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; } = null!;

        public double Value { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
