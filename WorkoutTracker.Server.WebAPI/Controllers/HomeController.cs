using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTracker.Server.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ConfigurationManager _configurationManager;

        public HomeController(ConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        [HttpGet(Name = "Index")]
        public IActionResult Index()
        {
            return Ok($"Works! ConnectionString: {_configurationManager.GetConnectionString("DefaultConnection")}");
        }
    }
}
