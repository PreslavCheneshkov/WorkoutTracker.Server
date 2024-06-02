using System.ComponentModel.DataAnnotations;
using WorkoutTracker.Server.Data.Common;

namespace WorkoutTracker.Server.Data.Entities.Exercise
{
    public class ExerciseParameterName : ISoftDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set ; }

        public DateTime? DeletedDate { get; set ; }
    }
}
