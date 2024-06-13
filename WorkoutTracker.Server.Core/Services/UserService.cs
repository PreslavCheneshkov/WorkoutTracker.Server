using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data;

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
}
