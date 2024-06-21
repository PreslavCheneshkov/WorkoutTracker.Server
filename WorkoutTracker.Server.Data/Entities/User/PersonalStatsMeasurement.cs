using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Server.Data.Entities.User;

public class PersonalStatsMeasurement
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(WorkoutTrackerUser))]
    public string WorkoutTrackerUserId { get; set; } = null!;

    public WorkoutTrackerUser WorkoutTrackerUser { get; set; } = null!;

    public DateTime? MeasurementDate { get; set; }

    [Range(0, double.MaxValue)]
    public double? WeightKilograms { get; set; }

    [Range(0, 100)]
    public double? BodyFatPercentage { get; set; }
}
