using Microsoft.AspNetCore.Mvc;

namespace WorkoutTracker.Server.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "Index")]
        public IActionResult Index()
        {
            return Ok($"Works!");
        }
    }
}
