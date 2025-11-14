using CarPark.Application.Dtos.Parking.Request;
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
        public async Task<IActionResult> VehicleEnter(VehicleEnter model)
        {


            if (!ModelState.IsValid)
            {
                var spotsResult = await _parkingService.GetAllSpotsAsync();
                return View("Index", spotsResult);

            }
            var result = await _parkingService.VehicleEnterAsync(model);

            if (!result.Success)
                TempData["ErrorMessage"] = result.Message;     
            else
                TempData["SuccessMessage"] = result.Message;
            

            return RedirectToAction("Index");
        }


        /// <summary>
        /// 1. adım: Plakaya göre çıkış ücretini hesaplar, başarılıysa ödeme modalını açtırır.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> VehicleExit(VehicleExitRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                var spotsResult = await _parkingService.GetAllSpotsAsync();
                return View("Index", spotsResult);
            }

            var priceResult = await _parkingService.CalculateVehicleExitPriceAsync(model);

            if (!priceResult.Success)
            {
                TempData["ErrorMessage"] = priceResult.Message;
                return RedirectToAction("Index");
            }

            var spotsResult2 = await _parkingService.GetAllSpotsAsync();
            ViewBag.ShowPaymentModal = true;
            ViewBag.ExitPlate = model.Plate;
            ViewBag.ExitPrice = priceResult.Data;

            return View("Index", spotsResult2);
        }

        /// <summary>
        /// 2. adım: Modal içindeki ödeme formu, valid ise gerçekten çıkışı tamamlar.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ConfirmExit(VehicleExitPayment model)
        {
            if (!ModelState.IsValid)
            {
                var spotsResult = await _parkingService.GetAllSpotsAsync();
                ViewBag.ShowPaymentModal = true;
                ViewBag.ExitPlate = model.Plate;
                var priceResult = await _parkingService.CalculateVehicleExitPriceAsync(new VehicleExitRequestDto { Plate = model.Plate });
                if (priceResult.Success)
                    ViewBag.ExitPrice = priceResult.Data;
                return View("Index", spotsResult);
            }
            var confirmResult = await _parkingService.ConfirmVehicleExitAsync(
                new VehicleExitRequestDto { Plate = model.Plate });
            if (confirmResult.Success)
                TempData["SuccessMessage"] = $"Çıkış işlemi ve ödeme tamamlandı. Toplam ücret: {confirmResult.Data} ₺";
            else
                TempData["ErrorMessage"] = confirmResult.Message;

            return RedirectToAction("Index");
        }
    }
}
