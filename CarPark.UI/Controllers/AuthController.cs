using CarPark.Application.Dtos.Auth.Request;
using CarPark.Application.IService;
using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarPark.UI.Controllers
{

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new Login());
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {

            if (!ModelState.IsValid)
                return View(model);
            
            var result = await _authService.LoginAsync(model);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message!);
                return View(model);
            }

           var claims = new List<Claim>
           {
              new Claim(ClaimTypes.Name, result.Data!.FullName)
           };

            var identity = new ClaimsIdentity(claims, "ParkingCookie");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("ParkingCookie", principal);
            return RedirectToAction("Index", "Parking");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("ParkingCookie");
            return RedirectToAction("Login");
        }
    }
}
