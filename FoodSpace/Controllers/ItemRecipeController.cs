using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodSpace.Controllers
{
    public class ItemRecipeController : Controller
    {

        private readonly ApplicationDbContext _db;


        public ItemRecipeController(ApplicationDbContext db) { 


            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StoreItem(int? id)
        {
            if (id != null)
            {
                var itemFromDb = _db.Item.Find(id);
                if (itemFromDb != null)
                {
                    
                }
            }
            
            return RedirectToAction("Index", "Item");
        }
    }
}
