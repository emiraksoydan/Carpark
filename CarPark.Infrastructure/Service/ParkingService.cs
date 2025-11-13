using CarPark.Application.Dtos.Parking;
using CarPark.Application.IRepository;
using CarPark.Application.IService;
using CarPark.Application.ResponseData;
using CarPark.Domain.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Infrastructure.Service
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingSpotRepository _spotRepository;
        private readonly IParkingTicketRepository _ticketRepository;

        public ParkingService(IParkingSpotRepository spotRepository, IParkingTicketRepository ticketRepository)
        {
            _spotRepository = spotRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<Result<List<ParkingSpotDto>>> GetAllSpotsAsync()
        {
            var spots = await _spotRepository.GetAllAsync();
            var list = spots.Select(s => new ParkingSpotDto
            {
                Id = s.Id,
                Code = s.Code,
                IsFilled = s.IsFilled,
                Plate = s.Plate,
                FilledAt = s.FilledAt
            }).ToList();

            return Result<List<ParkingSpotDto>>.Succeed(list);

        }

        public async Task<Result> VehicleEnterAsync(VehicleEnterRequestDto request)
        {
            var existingTicket = await _ticketRepository.GetActiveTicketByPlateAsync(request.Plate!);
            if (existingTicket != null)
                return Result.Fail("Bu plaka zaten otoparkta kayıtlı.");
            var spot = await _spotRepository.GetByIdAsync(request.SpotId ??= 0);
            if (spot == null)
                return Result.Fail("Seçilen park alanı bulunamadı.");
            if (spot.IsFilled)
                return Result.Fail("Seçilen park alanı dolu.");
            spot.IsFilled = true;
            spot.Plate = request.Plate;
            spot.FilledAt = DateTime.Now;
            await _spotRepository.UpdateAsync(spot);
            var ticket = new ParkingTicket
            {
                Plate = request.Plate!,
                SpotId = spot.Id,
                EnteredAt = DateTime.Now
            };
            await _ticketRepository.AddAsync(ticket);
            return Result.Succeed($"Araç {spot.Code} alanına alındı.");
        }

        public async Task<Result<decimal>> ConfirmVehicleExitAsync(VehicleExitRequestDto request)
        {
            var ticket = await _ticketRepository.GetActiveTicketByPlateAsync(request.Plate!);
            if (ticket == null)
                return Result<decimal>.Fail("Bu plakaya ait aktif kayıt bulunamadı.");

            ticket.ExitedAt = DateTime.Now;
            var duration = ticket.ExitedAt.Value - ticket.EnteredAt;
            var hours = Math.Ceiling(duration.TotalHours);
            var price = (decimal)hours * 50m;
            ticket.TotalPrice = price;

            await _ticketRepository.UpdateAsync(ticket);

            var spot = await _spotRepository.GetByIdAsync(ticket.SpotId);

            if (spot != null)
            {
                spot.IsFilled = false;
                spot.Plate = null;
                spot.FilledAt = null;
                await _spotRepository.UpdateAsync(spot);
            }

            return Result<decimal>.Succeed(price, "Çıkış işlemi başarılı.");
        }

        public async Task<Result<decimal>> CalculateVehicleExitPriceAsync(VehicleExitRequestDto request)
        {
            var ticket = await _ticketRepository.GetActiveTicketByPlateAsync(request.Plate!);
            if (ticket == null)
                return Result<decimal>.Fail("Bu plakaya ait aktif kayıt bulunamadı.");

            var now = DateTime.Now;
            var duration = now - ticket.EnteredAt;
            var hours = Math.Ceiling(duration.TotalHours);
            var price = (decimal)hours * 50m;

            return Result<decimal>.Succeed(price);
        }


    }
}
