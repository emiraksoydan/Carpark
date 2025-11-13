using CarPark.Application.IRepository;
using CarPark.Domain.Modals;
using CarPark.Infrastructure.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Infrastructure.Repository
{
    public class ParkingTicketRepository : IParkingTicketRepository
    {
        public Task AddAsync(ParkingTicket ticket)
        {
            InMemoryNonDb.Tickets.Add(ticket);
            return Task.CompletedTask;

        }

        public Task<ParkingTicket?> GetActiveTicketByPlateAsync(string plate)
        {
            return Task.FromResult(
            InMemoryNonDb.Tickets
                .SingleOrDefault(x => x.Plate == plate && x.ExitedAt == null));
        }

        public Task UpdateAsync(ParkingTicket ticket)
        {
            return Task.CompletedTask;
        }
    }
}
