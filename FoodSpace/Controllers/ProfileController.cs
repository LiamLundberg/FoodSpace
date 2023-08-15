using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using FoodSpace.Models;
using FoodSpace.Data;

namespace FoodSpace.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

            // Redirect to the desired page after logout
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddProfileInitial(Profile profile)
        {
            Profile? temp = _db.Profile.Find(profile.ProfileID);

            if (temp == null)
            {
                _db.Profile.Add(temp);

                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult PreferencesMenu()
        {
            
            return View("Preferences", new Profile{  });
        }
    }
}
