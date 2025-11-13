using CarPark.Application.Dtos.Ticket;
using CarPark.Application.IRepository;
using CarPark.Application.IService;
using CarPark.Application.ResponseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Infrastructure.Service
{
    public class TicketService : ITicketService
    {
        private readonly IParkingTicketRepository _ticketRepository;
        private readonly IParkingSpotRepository _spotRepository;

        public TicketService(IParkingTicketRepository ticketRepository,
                             IParkingSpotRepository spotRepository)
        {
            _ticketRepository = ticketRepository;
            _spotRepository = spotRepository;
        }
        public async Task<Result<List<ParkingTicketDto>>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            var spots = await _spotRepository.GetAllAsync();

            var list = tickets
                .Select(t =>
                {
                    var spot = spots.FirstOrDefault(s => s.Id == t.SpotId);

                    return new ParkingTicketDto
                    {
                        Id = spot?.Id ?? 0,
                        Plate = t.Plate,
                        SpotCode = spot?.Code ?? "-",
                        EnteredAt = t.EnteredAt,
                        ExitedAt = t.ExitedAt,
                        TotalPrice = t.TotalPrice
                    };
                })
                .ToList();

            return Result<List<ParkingTicketDto>>.Succeed(list);
        }
    }
}
