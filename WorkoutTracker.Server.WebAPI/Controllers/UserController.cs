using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Server.Core.Services.Contracts;
using WorkoutTracker.Server.Data.Entities.User;
using WorkoutTracker.Server.WebAPI.ApiModels.Input;

namespace WorkoutTracker.Server.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : WorkoutTrackerController
{
    private readonly IUserService _userService;
    private readonly UserManager<WorkoutTrackerUser> _userManager;

    public UserController(IUserService userService, UserManager<WorkoutTrackerUser> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    [HttpPost]
    [Route("Username")]
    public async Task<IActionResult> SetUsername([FromBody]UsernameInputModel usernameInput)
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return Unauthorized();
        }
        if (string.IsNullOrEmpty(usernameInput.Username))
        {
            return BadRequest();
        }
        var success = await _userService.SetUsernameAsync(usernameInput.Username, userId);
        if (success)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet]
    [Route("Username")]
    public async Task<IActionResult> GetUsername()
    {
        var userId = _userManager.GetUserId(User);
        if (userId is null)
        {
            return Unauthorized();
        }
        var username = await _userService.GetUsernameAsync(userId);
        return Ok(username);
    }
}
