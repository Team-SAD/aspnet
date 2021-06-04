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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // var client = new HttpClient();
            // var response = await client.GetAsync($"{_confirguration["Services:aspnet"]}/home);
            // var result = null;

            // if (response == IsSuccessStatusCode)
            // {
            //     json
            // }

            //var response = await BaseWebClient.Client.GetAsync($"Home");
            
            return View("index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
