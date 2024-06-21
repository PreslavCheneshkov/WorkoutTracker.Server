using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Server.Data.Entities.User;

public class WorkoutTrackerUser : IdentityUser
{
    [Range(0, double.MaxValue)]
    public double? CurrentWeightKg { get; set; }

    [Range(0, 100)]
    public double? CurrentBodyfatPercentage { get; set; }
}
