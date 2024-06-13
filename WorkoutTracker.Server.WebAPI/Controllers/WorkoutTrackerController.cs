using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTracker.Server.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class WorkoutTrackerController : ControllerBase
    {
    }
}
