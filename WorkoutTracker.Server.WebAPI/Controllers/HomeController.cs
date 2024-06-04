﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTracker.Server.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet(Name = "Index")]
        public IActionResult Index()
        {
            return Ok("Works!");
        }
    }
}
