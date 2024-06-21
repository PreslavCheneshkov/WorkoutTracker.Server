using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Server.Core.ServiceModels.User;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data;
using WorkoutTracker.Server.Data.Entities.User;

namespace WorkoutTracker.Server.Core.Services;

public class UserService : IUserService
{
    private readonly WorkoutTrackerDbContext _db;

    public UserService(WorkoutTrackerDbContext db)
    {
        _db = db;
    }

    public async Task<string?> GetUsernameAsync(string userId)
    {
        return await _db.Users.Where(u => u.Id == userId).Select(u => u.UserName).FirstOrDefaultAsync();
    }

    public async Task<bool> SetUsernameAsync(string username, string userId)
    {
        var user = await _db.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        if (user is null)
        {
            return false;
        }
        user.UserName = username;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<BodyfatHistoryDataPointServiceModel>> GetBodyfatPercentageHistoryAsync(string userId)
    {
        return await _db.PersonalStats.Where(ps => ps.WorkoutTrackerUserId == userId && ps.BodyFatPercentage != null)
            .Select(ps => new BodyfatHistoryDataPointServiceModel
            {
                BodyfatPercentage = ps.BodyFatPercentage,
                MeasurementDate = ps.MeasurementDate,
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<WeightHistoryDataPointServiceModel>> GetWeightHistoryAsync(string userId)
    {
        return await _db.PersonalStats.Where(ps => ps.WorkoutTrackerUserId == userId && ps.WeightKilograms != null)
            .Select(ps => new WeightHistoryDataPointServiceModel
            {
                MeasurementDate = ps.MeasurementDate,
                WeightKilograms = ps.WeightKilograms
            })
            .ToListAsync();
    }

    public async Task<PersonalStatsServiceModel> GetPersonalStatsAsync(string userId)
    {
        var user = await _db.Users.FirstAsync(u => u.Id == userId);
        return new PersonalStatsServiceModel
        {
            BodyFatPercentage = user.CurrentBodyfatPercentage,
            WeightKilograms = user.CurrentWeightKg
        };
    }

    public async Task SetPersonalStats(double? weightKilograms, double? bodyFatPercentage, string userId)
    {
        if (weightKilograms is null && bodyFatPercentage is null)
        {
            return;
        }
        var personalStat = new PersonalStatsMeasurement
        {
            BodyFatPercentage = bodyFatPercentage,
            WeightKilograms = weightKilograms,
            WorkoutTrackerUserId = userId,
            MeasurementDate = DateTime.UtcNow
        };
        _db.PersonalStats.Add(personalStat);
        var user = await _db.Users.FirstAsync(u => u.Id == userId);
        if (weightKilograms != null)
        {
            user.CurrentWeightKg = weightKilograms;
        }
        if (bodyFatPercentage != null)
        {
            user.CurrentBodyfatPercentage = bodyFatPercentage;
        }
        await _db.SaveChangesAsync();
    }

}
