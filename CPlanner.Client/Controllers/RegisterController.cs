using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPlanner.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPlanner.Client.Controllers
{
    [Route("[controller]")]
    public class RegisterController : Controller
    {
         [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerViewModel user)
        {
            using( var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                var response = await client.PostAsJsonAsync("https://localhost:5001/api/account/register", user);

                if(response.IsSuccessStatusCode)
                {
                    TempData["Name"] = user.Name;
                    //return Ok("New user added");
                    return View(user);

                }

            }
            return Ok("Unable to add user");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CustomerViewModel user)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                var response = await client.PostAsJsonAsync("https://localhost:5001/api/account/login", user);
                if(response.IsSuccessStatusCode)
                {
                    return View(user);
                }
            }
            return Ok("Unable to login");
        }
    }
}