using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FoodSpace.Controllers
{
    public class DynamicRecipeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DynamicRecipeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: DynamicRecipeController
        public IActionResult Index()
        {
            IEnumerable<DynamicRecipe> objItemList = _db.DynamicRecipes.OrderBy(x => x.Name);

            return View(objItemList);
        }

        // GET: DynamicRecipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DynamicRecipe obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order Cannot exactly match name");
            }
            if (ModelState.IsValid)
            {
                _db.DynamicRecipes.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Recipe Created Successfully";
                return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going to antoher controller
            }
            return View(obj);
        }

        // GET: DynamicRecipeController/Edit/5
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

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var itemFromDb = _db.DynamicRecipes.Find(id);
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
            var obj = _db.DynamicRecipes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.DynamicRecipes.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Recipe Deleted Successfully";
            return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going to antoher controller
        }
    }
}
