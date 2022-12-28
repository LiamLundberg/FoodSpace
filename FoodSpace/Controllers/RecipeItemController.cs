using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodSpace.Controllers
{
    public class RecipeItemController : Controller
    {

        private readonly ApplicationDbContext _db;
        private FoodSearchResult _foodSearchResult;

        public RecipeItemController(ApplicationDbContext db, FoodSearchResult foodSearchResult) { 

            _foodSearchResult = foodSearchResult;
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
                var itemFromDb = _db.Items.Find(id);
                if (itemFromDb != null)
                {
                    
                }
            }
            
            return RedirectToAction("Index", "Item");
        }
    }
}
