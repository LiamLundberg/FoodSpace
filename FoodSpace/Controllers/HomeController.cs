using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FoodSpace.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Fetch(SearchCriteria obj)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://api.nal.usda.gov/fdc/v1/foods/search?query=" + obj.criteria + "&pageSize=2&api_key=SYp8Cnp4xiIclRvd2hRFL1bPKCGDBpfnlDP7wf0u");

                var json = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;


                while(json == null)
                {
                    
                }
                FoodSearchResult result = JsonConvert.DeserializeObject<FoodSearchResult>(json);

               }
            
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}