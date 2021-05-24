using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CPlanner.Client.Models;

namespace CPlanner.Client.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // var client = new HttpClient();
            // var response = await client.GetAsync($"{_confirguration["Services:aspnet"]}/home);
            // var result = null;

            // if (response == IsSuccessStatusCode)
            // {
            //     json
            // }
            return View("index");

        }
    }
}
