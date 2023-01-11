using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Immutable;

namespace FoodSpace.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RecipeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: DynamicRecipeController
        public IActionResult Index()
        {
            IEnumerable<Recipe> objItemList = _db.Recipe.OrderBy(x => x.Name);

            return View(objItemList);
        }

        // GET: DynamicRecipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult RecipeInfo(int id)
        {
            ItemRecipe[] itemRecipeList = _db.ItemRecipe.Where(y => y.RecipeId == id).ToArray();
            
            if (itemRecipeList.Length > 0) {
                itemRecipeList.First().Recipe = _db.Recipe.Find(id);

                Item itemTemp = new Item();
                foreach (var item in itemRecipeList)
                {
                    itemTemp = _db.Item.Find(item.ItemId);
                    if (itemTemp != null)
                    {
                        item.Item = itemTemp;
                    }
                    
                }
            }
            else
            {
                IEnumerable<Recipe> objItemList = _db.Recipe.OrderBy(x => x.Name);
                return View("Index", objItemList);
            }
            
            
            return View(itemRecipeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Recipe obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order Cannot exactly match name");
            }
            if (ModelState.IsValid)
            {
                _db.Recipe.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Recipe Created Successfully";
                return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going to antoher controller
            }
            return View(obj);
        }

        public IActionResult Select(int id)
        {
            TempData["SelectedRecipe"] = id;
            
            IEnumerable<Recipe> objItemList = _db.Recipe.OrderBy(x => x.Name);
            return View("Index", objItemList);
        }

        // GET: DynamicRecipeController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DynamicRecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var itemFromDb = _db.Recipe.Find(id);
            //var itemFromDbFirst = _db.Items.FirstOrDefault(x => x.Id == id);
            //var itemFromDBSingle = _db.Items.SingleOrDefault(x => x.Id == id);

            if (itemFromDb == null)
            {
                return NotFound();
            }

            return View(itemFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Recipe.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Recipe.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Recipe Deleted Successfully";
            return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going to antoher controller
        }
    }
}
