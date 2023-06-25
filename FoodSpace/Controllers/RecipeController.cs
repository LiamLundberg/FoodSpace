using FoodSpace.Data;
using FoodSpace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Immutable;

namespace FoodSpace.Controllers
{
    [AllowAnonymous]
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
                Step[] step = _db.Step.Where(h => h.RecipeId == id).OrderBy(x => x.StepNumber).ToArray();
                itemRecipeList.First().Recipe.Steps = step;
                Item itemTemp = new Item();
                foreach (var item in itemRecipeList)
                {
                    itemTemp = _db.Item.Find(item.ItemId);
                    if (itemTemp != null)
                    {
                        itemRecipeList.First().Recipe.Carbohydrates += Math.Round(item.Item.Carbohydrates * (item.Amount / 100f));
                        itemRecipeList.First().Recipe.Fat += Math.Round(item.Item.Fat * (item.Amount / 100f));
                        itemRecipeList.First().Recipe.Protein += Math.Round(item.Item.Protein * (item.Amount / 100f));
                        
                        item.Item = itemTemp;
                    }
                }
            }
            else
            {
                ItemRecipe temp = new ItemRecipe();
                temp.Recipe = _db.Recipe.Find(id);
                temp.RecipeId = id;
                ItemRecipe[] templist = new ItemRecipe[] { temp };
                Step[] step = _db.Step.Where(h => h.RecipeId == id).OrderBy(x => x.StepNumber).ToArray();
                templist.First().Recipe.Steps = step;
                Item itemTemp = new Item();
                foreach (var item in templist)
                {
                    itemTemp = _db.Item.Find(item.ItemId);
                    if (itemTemp != null)
                    {
                        templist.First().Recipe.Carbohydrates += Math.Round(item.Item.Carbohydrates * (item.Amount / 100f));
                        templist.First().Recipe.Fat += Math.Round(item.Item.Fat * (item.Amount / 100f));
                        templist.First().Recipe.Protein += Math.Round(item.Item.Protein * (item.Amount / 100f));

                        item.Item = itemTemp;
                    }
                }
                return View(templist);
            }


            return View(itemRecipeList);
        }

        public IActionResult Step(int id)
        {

            Step[] stepsFromDB = _db.Step.Where(x => x.RecipeId == id).OrderBy(x => x.StepNumber).ToArray();

            Step step;

            int counter = 1;

            foreach(var i in stepsFromDB)
            {
                if (i.StepNumber != counter) 
                    break; 
                counter++;
            }

            if (stepsFromDB.Length == 0 || stepsFromDB.First().StepNumber != 1)
            {
                step = new Step();
                step.RecipeId = id;
                step.StepNumber = 1;
                step.Description = "";
                step.Title = "";
            }
            else if(counter - 1 == stepsFromDB.Last().StepNumber)
            {
                step = _db.Step.Where(x => x.RecipeId == id).Where(x => x.StepNumber == counter - 1).First();
            }
            else
            {
                step = new Step();
                step.RecipeId = id;
                step.StepNumber = counter;
                step.Description = "";
                step.Title = "";
                _db.Step.Add(step);
                _db.SaveChanges();
            }

            step.Recipe = _db.Recipe.Find(step.RecipeId);

            

            return View(step);
        }

        public IActionResult StepNext(int? id)
        {
            Step stepfromDB = _db.Step.Find(id);
            ICollection<Step> stepsfromDB = _db.Step.Where(x => x.RecipeId == stepfromDB.RecipeId).ToArray();
            Recipe recipefromDB = _db.Recipe.Find(stepfromDB.RecipeId);
            bool found = false;
            int stepcount = 1;
            foreach (Step step in stepsfromDB)
            {
                if (step.StepNumber == stepfromDB.StepNumber + 1)
                {
                    stepfromDB = step;

                    found = true;
                    stepcount = stepfromDB.StepNumber;
                    break;
                }
            }

            if (found)
            {
                if (stepfromDB != null)
                {

                    return View("Step", stepfromDB);
                }
                else
                {
                    Step step = new Step();

                    step.StepNumber = stepfromDB.StepNumber;
                    step.Description = stepfromDB.Description;
                    step.Recipe = recipefromDB;
                    return View("Step", step);
                }
            }else
            {
                Step step = new Step();
                step.StepNumber = stepfromDB.StepNumber + 1;
                step.Description = "";
                step.Recipe = recipefromDB;
                step.RecipeId = stepfromDB.RecipeId;
                return View("Step", step);
            }
        }

        public IActionResult StepPrev(int id)
        {

            Step stepfromDB = _db.Step.Find(id);
            ICollection<Step> stepsfromDB = _db.Step.Where(x => x.RecipeId == stepfromDB.RecipeId).ToArray();
            Recipe recipefromDB = _db.Recipe.Find(stepfromDB.RecipeId);

            
            foreach (Step step in stepsfromDB)
            {
                if (step.StepNumber == stepfromDB.StepNumber - 1)
                {
                    stepfromDB = step;
                    break;
                }
            }

            
                if (stepfromDB != null)
                {

                    return View("Step", stepfromDB);
                }
                else
                {
                    Step step = new Step();

                    step.StepNumber = stepfromDB.StepNumber;
                    step.Description = stepfromDB.Description;
                    step.Recipe = recipefromDB;
                    return View("Step", step);
                }
            
            
        }

        [HttpPost]
        public IActionResult AddStep(Step step)
        {
            Step? temp = _db.Step.Find(step.StepId);

            if (temp == null)
            {
                _db.Step.Add(step);
            }
            else
            {
                _db.Step.Remove(temp);
                _db.Step.Add(step);
            };
            
            _db.SaveChanges();

            return RedirectToAction("RecipeInfo", new { id = step.RecipeId });
        }

        public IActionResult DeleteStep(Step step)
        {
            Step[] objs = _db.Step.Where(x => x.RecipeId == step.RecipeId & x.StepNumber == step.StepNumber).ToArray();
            if (objs != null)
            {
                foreach(var item in objs)
                {
                    _db.Step.Remove(item);
                }
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
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

        public IActionResult DeleteRecipeItem(int id)
        {
            var obj = _db.ItemRecipe.Find(id);
            _db.ItemRecipe.Remove(obj);
            IEnumerable<Recipe> objItemList = _db.Recipe.OrderBy(x => x.Name);
            _db.SaveChanges();
            return View("Index", objItemList);
        }

        public IActionResult Select(int id)
        {
            TempData["SelectedRecipe"] = id;
            
            IEnumerable<Recipe> objItemList = _db.Recipe.OrderBy(x => x.Name);
            return RedirectToAction("Index", "Item");
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

            ICollection<Step> steps = _db.Step.Where(x => x.RecipeId == obj.RecipeId).ToArray();
            foreach (var step in steps)
            {
                _db.Step.Remove(step);
            }
            ICollection<ItemRecipe> itemRecipes = _db.ItemRecipe.Where(x => x.RecipeId == obj.RecipeId).ToArray();
            foreach (var itemRecipe in itemRecipes)
            {
                _db.ItemRecipe.Remove(itemRecipe);
            }

            _db.Recipe.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Recipe Deleted Successfully";
            return RedirectToAction("Index"); //this can be done as return RedirectToAction("Index", "Home"); if we are going to antoher controller
        }
    }
}
