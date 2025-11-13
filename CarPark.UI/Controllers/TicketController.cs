using Microsoft.AspNetCore.Mvc;

namespace CarPark.UI.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
