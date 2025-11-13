using CarPark.Domain.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.IRepository
{
    public interface IParkingTicketRepository
    {
        Task<ParkingTicket?> GetActiveTicketByPlateAsync(string plate);
        Task AddAsync(ParkingTicket ticket);
        Task UpdateAsync(ParkingTicket ticket);
    }
}
