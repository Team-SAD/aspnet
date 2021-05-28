using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CPlanner.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CPlanner.Client.Controllers
{
     [Route("[controller]")]
    public class CustomerController : Controller
    {
        public CustomerController()
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Customers = new List<CustomerViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                //client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/customer/users");

                if(response.IsSuccessStatusCode)
                {
                    var eventResponse = response.Content.ReadAsStringAsync().Result;

                    Customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(eventResponse);
                    
                }
                return View(Customers);
            
            }
        }

       


    }
}