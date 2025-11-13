using CarPark.Application.Dtos.Parking;
using CarPark.Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.UI.Controllers
{
    [Authorize]
    public class ParkingController : Controller
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        public async Task<IActionResult> Index()
        {
            var spotsResult = await _parkingService.GetAllSpotsAsync();
            return View(spotsResult);
        }



        [HttpPost]
        public async Task<IActionResult> VehicleEnter(VehicleEnterRequestDto model)
        {

            if (model.SpotId <= 0)
            {
                var spotsResult = await _parkingService.GetAllSpotsAsync();
                ViewBag.ErrorMessage = "Lütfen boş bir park alanı seçin";
                return View("Index", spotsResult);
            }

            if (!ModelState.IsValid)
            {
                var spotsResult = await _parkingService.GetAllSpotsAsync();
                return View("Index", spotsResult);
            }
            var result = await _parkingService.VehicleEnterAsync(model);
            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;

            }
   
                return RedirectToAction("Index");
        }
        

        [HttpPost]
        public async Task<IActionResult> VehicleExit(VehicleExitRequestDto model)
        {
            var result = await _parkingService.VehicleExitAsync(model);
            if (result.Success)
                ViewBag.SuccessMessage = $"Toplam ücret: {result.Data} ₺";
            else
                ViewBag.ErrorMessage = $" {result.Message}";

            return RedirectToAction("Index");
        }
    }
}
