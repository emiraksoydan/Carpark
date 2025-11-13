using CarPark.Application.Dtos.Parking;
using CarPark.Application.ResponseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.IService
{
    public interface IParkingService
    {
        Task<Result<List<ParkingSpotDto>>> GetAllSpotsAsync();
        Task<Result> VehicleEnterAsync(VehicleEnterRequestDto request);
        Task<Result<decimal>> CalculateVehicleExitPriceAsync(VehicleExitRequestDto request);
        Task<Result<decimal>> ConfirmVehicleExitAsync(VehicleExitRequestDto request);


    }
}
