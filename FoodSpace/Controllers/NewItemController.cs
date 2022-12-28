using Azure;
using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodSpace.Controllers
{
    public class NewItemController : Controller
    {
       public IActionResult Index(SearchCriteria obj)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://api.nal.usda.gov/fdc/v1/foods/search?query=" + obj.criteria + "&pageSize=" +  obj.pageSize + "&api_key=SYp8Cnp4xiIclRvd2hRFL1bPKCGDBpfnlDP7wf0u");
                
                var json = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;

                FoodSearchResult result = JsonConvert.DeserializeObject<FoodSearchResult>(json);


                return View(result);
            }
        }
    }
}
