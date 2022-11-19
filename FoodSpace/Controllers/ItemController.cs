using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodSpace.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objItemList = _db.Items;

            return View(objItemList);
        }
    }
}
