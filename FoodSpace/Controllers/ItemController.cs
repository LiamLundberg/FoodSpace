using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodSpace.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
            
        }

        public IActionResult Index(string sortOrder)
        {
            IEnumerable<Item> objItemList = _db.Items.OrderBy(x => x.Name);

            if (sortOrder.IsNullOrEmpty())
            {
                objItemList = _db.Items.OrderBy(x => x.Name);
            }
            else
            {
                switch (sortOrder)
            {
                case "nameSort":
                    if (TempData["sort"] == null || TempData["sort"].Equals("asc"))
                    {
                        objItemList = _db.Items.OrderBy(x => x.Name);
                        TempData["sort"] = "desc";
                    }
                    else
                    {
                        objItemList = _db.Items.OrderByDescending(x => x.Name);
                        TempData["sort"] = "asc";
                    }

                    break;
                case "proteinSort":
                    if (TempData["sort"] == null || TempData["sort"].Equals("asc") )
                    {
                        objItemList = _db.Items.OrderBy(x => x.Protein);
                        TempData["sort"] = "desc";
                    }
                    else
                    {
                        objItemList = _db.Items.OrderByDescending(x => x.Protein);
                        TempData["sort"] = "asc";
                    }

                    break;
                case "fatSort":
                    if (TempData["sort"] == null || TempData["sort"].Equals("asc"))
                    {
                        objItemList = _db.Items.OrderBy(x => x.Fat);
                        TempData["sort"] = "desc";
                    }
                    else
                    {
                        objItemList = _db.Items.OrderByDescending(x => x.Fat);
                        TempData["sort"] = "asc";
                    }

                    break;
                case "carbSort":
                    if (TempData["sort"] == null || TempData["sort"].Equals("asc"))
                    {
                        objItemList = _db.Items.OrderBy(x => x.Carbohydrates);
                        TempData["sort"] = "desc";
                    }
                    else
                    {
                        objItemList = _db.Items.OrderByDescending(x => x.Carbohydrates);
                        TempData["sort"] = "asc";
                    }
                        
                    break;
            }
            }

            

            return View(objItemList);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order Cannot exactly match name");
                ModelState.AddModelError("DisplayOrder", "Display Order Cannot exactly match name");
            }
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going ot antoher controller
            }
            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) {
            return NotFound();
            }
            var itemFromDb = _db.Items.Find(id);
            //var itemFromDbFirst = _db.Items.FirstOrDefault(x => x.Id == id);
            //var itemFromDBSingle = _db.Items.SingleOrDefault(x => x.Id == id);

            if (itemFromDb == null)
            {
                return NotFound();
            }

            return View(itemFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order Cannot exactly match name");
                ModelState.AddModelError("DisplayOrder", "Display Order Cannot exactly match name");
            }
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edited Successfully";
                return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going ot antoher controller
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var itemFromDb = _db.Items.Find(id);
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
            var obj = _db.Items.Find(id);
            if(obj == null) { 
                return NotFound();
            }

            _db.Items.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going to antoher controller
        }
    }
}
