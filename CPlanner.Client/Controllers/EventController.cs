using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using CPlanner.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;



namespace CPlanner.Client.Controllers
{
    [Route("[controller]")]
    public class EventController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var Events = new List<EventViewModel>();
        
           using (var client = new HttpClient())
           {
               client.BaseAddress = new Uri("https://localhost:5001/");
               client.DefaultRequestHeaders.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

               var response = await client.GetAsync("api/event/events");

               if(response.IsSuccessStatusCode)
               {
                   var eventResponse = response.Content.ReadAsStringAsync().Result;

                   Events = JsonConvert.DeserializeObject<List<EventViewModel>>(eventResponse);
                //    if(!String.IsNullOrEmpty(searchString))
                //    {
                //        Events = events.Where(e => e.Title.Contains(searchString)
                //                             || e.Description.Contains(searchString)).ToList();
                //    }
                   
               }
               return View(Events.ToList());
               
           }

        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(EventViewModel eventItem)
        {
            using( var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001");
                var response = await client.PostAsJsonAsync("api/event/create", eventItem);

                if(response.IsSuccessStatusCode)
                {
                    TempData["Title"] = eventItem.Title;
                    TempData["Descriionpt"] = eventItem.Description;
                    return RedirectToAction("Index");

                }

            }
            return Ok("Unable to add Event");
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEvent(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using( var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001");
                var response = await client.PostAsJsonAsync("api/event/edit", id);

                if(response.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction(nameof(Index));

                }

            }
            return View("Index");
        }   

        
    }
}