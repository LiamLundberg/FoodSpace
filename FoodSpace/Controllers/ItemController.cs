using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace FoodSpace.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
            IList<Item> items = new List<Item>();
        }

        public IActionResult Index(string sortOrder)
        {
            IEnumerable<Item> objItemList = _db.Item.OrderBy(x => x.Name);

            if (sortOrder.IsNullOrEmpty())
            {
                objItemList = _db.Item.OrderBy(x => x.Name);
            }
            else
            {
                switch (sortOrder)
            {
                case "nameSort":
                    if (TempData["sort"] == null || TempData["sort"].Equals("asc"))
                    {
                        objItemList = _db.Item.OrderBy(x => x.Name);
                        TempData["sort"] = "desc";
                    }
                    else
                    {
                        objItemList = _db.Item.OrderByDescending(x => x.Name);
                        TempData["sort"] = "asc";
                    }

                    break;
                case "proteinSort":
                    if (TempData["sort"] == null || TempData["sort"].Equals("asc") )
                    {
                        objItemList = _db.Item.OrderBy(x => x.Protein);
                        TempData["sort"] = "desc";
                    }
                    else
                    {
                        objItemList = _db.Item.OrderByDescending(x => x.Protein);
                        TempData["sort"] = "asc";
                    }

                    break;
                case "fatSort":
                    if (TempData["sort"] == null || TempData["sort"].Equals("asc"))
                    {
                        objItemList = _db.Item.OrderBy(x => x.Fat);
                        TempData["sort"] = "desc";
                    }
                    else
                    {
                        objItemList = _db.Item.OrderByDescending(x => x.Fat);
                        TempData["sort"] = "asc";
                    }

                    break;
                case "carbSort":
                    if (TempData["sort"] == null || TempData["sort"].Equals("asc"))
                    {
                        objItemList = _db.Item.OrderBy(x => x.Carbohydrates);
                        TempData["sort"] = "desc";
                    }
                    else
                    {
                        objItemList = _db.Item.OrderByDescending(x => x.Carbohydrates);
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
                _db.Item.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going ot antoher controller
            }
            return View(obj);
        }

       
        public IActionResult SearchItem(SearchCriteria obj)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://api.nal.usda.gov/fdc/v1/foods/search?query=" + obj.criteria + "&pageSize=" + obj.pageSize + "&api_key=SYp8Cnp4xiIclRvd2hRFL1bPKCGDBpfnlDP7wf0u");

                var json = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;

                FoodSearchResult result = JsonConvert.DeserializeObject<FoodSearchResult>(json);

                return View("NewItem", result);
            }
        }

        public IActionResult AddToRecipe(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var itemFromDb = _db.Item.Find(id);
            var recipeFromDb = _db.Recipe.Find((int)TempData.Peek("SelectedRecipe"));
            ItemRecipe tempItemRecipe = new ItemRecipe();
            tempItemRecipe.Item = itemFromDb;
            tempItemRecipe.ItemId = itemFromDb.ItemId;
            tempItemRecipe.Recipe = recipeFromDb;
            tempItemRecipe.RecipeId = recipeFromDb.RecipeId;

            if (itemFromDb == null)
            {
                return NotFound();
            }

            return View(tempItemRecipe);
        }
        
        public IActionResult AddToRecipePOST(ItemRecipe itemRecipe)
        {
            
            TempData["success"] = "Item Added To Recipe";
            _db.ItemRecipe.Add(itemRecipe);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Import(int fdcID)
        {

            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://api.nal.usda.gov/fdc/v1/food/" + fdcID + "?api_key=SYp8Cnp4xiIclRvd2hRFL1bPKCGDBpfnlDP7wf0u&format=abridged");

                var json = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;

                Foods result = JsonConvert.DeserializeObject<Foods>(json);


                Item newItem = new Item();
                newItem.Name = result.description;

                foreach (var obj in result.foodNutrients)
                {
                    if (obj.name == "Protein")
                    {
                        newItem.Protein = obj.amount;
                    }
                    else if (obj.name == "Total lipid (fat)")
                    {
                        newItem.Fat = obj.amount;
                    }
                    else if (obj.name == "Carbohydrate, by difference")
                    {
                        newItem.Carbohydrates = obj.amount;
                    }

                }

                _db.Item.Add(newItem);
                _db.SaveChanges();
            }

            
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) {
            return NotFound();
            }
            var itemFromDb = _db.Item.Find(id);
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
            }
            if (ModelState.IsValid)
            {
                _db.Item.Update(obj);
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
            var itemFromDb = _db.Item.Find(id);
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
            var obj = _db.Item.Find(id);
            if(obj == null) { 
                return NotFound();
            }

            _db.Item.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going to antoher controller
        }  
    }
}
