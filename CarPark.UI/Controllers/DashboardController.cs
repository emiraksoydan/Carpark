using Microsoft.AspNetCore.Mvc;

namespace CarPark.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
