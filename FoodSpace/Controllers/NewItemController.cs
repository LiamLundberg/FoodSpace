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
            return View();
        }

    }
}
