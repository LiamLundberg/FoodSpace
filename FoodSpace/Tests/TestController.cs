using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodSpace.Controllers;
using FoodSpace.Models;
using FoodSpace.Data;
using System.Collections.Generic;

namespace FoodSpace.Tests
{
    public class TestController
    {
       
        [TestClass]
        public class ItemControllerTest
        {

            private readonly ApplicationDbContext _db;

            public ItemControllerTest(ApplicationDbContext db)
            {
                _db = db;
                IList<Item> items = new List<Item>();
            }

            [TestMethod]
            public void TestItemsIndexView()
            {
                var controller = new ItemController(_db);
                var result = controller.Index("nameSort") as ViewResult;
                IEnumerable<Item> items = (IEnumerable<Item>) result.ViewData.Model;
                Assert.AreEqual("Apple", items.First().Name);
            }
        }
    }
}
