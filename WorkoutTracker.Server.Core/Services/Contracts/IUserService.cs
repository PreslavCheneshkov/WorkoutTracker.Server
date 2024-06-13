namespace WorkoutTracker.Server.Core.Services.Contracts;

public interface IUserService
{
    Task<bool> SetUsernameAsync(string username, string userId);

    Task<string?> GetUsernameAsync(string userId);
}
