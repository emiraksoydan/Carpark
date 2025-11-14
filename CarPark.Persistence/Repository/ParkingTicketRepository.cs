using CarPark.Application.IRepository;
using CarPark.Domain.Modals;
using CarPark.Persistence.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Persistence.Repository
{
    public class ParkingTicketRepository : IParkingTicketRepository
    {
     

        public Task AddAsync(ParkingTicket ticket)
        {
            InMemoryNonDb.Tickets.Add(ticket);
            return Task.CompletedTask;

        }

        public Task<ParkingTicket?> GetActiveTicketByPlateAsync(string plate) =>
             Task.FromResult(
            InMemoryNonDb.Tickets
                .SingleOrDefault(x => x.Plate == plate && x.ExitedAt == null));
        

        public Task<List<ParkingTicket>> GetAllAsync()
        => Task.FromResult(InMemoryNonDb.Tickets
            .OrderByDescending(t => t.EnteredAt)
            .ToList());


        
    }
}
