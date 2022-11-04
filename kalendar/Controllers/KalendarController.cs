using kalendar.Models;
using kalendar.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;

namespace kalendar.Controllers
{
    public class KalendarController : Controller
    {
        private readonly ILogger<KalendarController> _logger;

        public KalendarController(ILogger<KalendarController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          /* IEnumerable<Udalost> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:7007/api/");
                //HTTP GET
                var responseTask = client.GetAsync("udalost");

                var result = responseTask.Result;
                students = (IEnumerable<Udalost>?)responseTask.Result;
            }*/
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}