using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Server.Data.Entities.Exercise
{
    public class ExerciseParameter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public double Value { get; set; }

        [Required]
        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; } = null!;
    }
}
