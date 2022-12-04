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

        // GET: DynamicRecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DynamicRecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DynamicRecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DynamicRecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
