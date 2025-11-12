using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.UI.Controllers
{

    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View(); 

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
    
            return RedirectToAction("Index", "Park");
        }

        [HttpGet]
        public IActionResult Register() => View(); // Views/Auth/Register.cshtml

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Register(string firstName, string lastName, string userName, string password)
        {
            // kayıt + otomatik login (senin senaryona uygun)
            return RedirectToAction("Index", "Park");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Logout()
        {
            // HttpContext.SignOutAsync(...);
            return RedirectToAction("Login");
        }
    }
}
