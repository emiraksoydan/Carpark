using CarPark.Application.Dtos.Ticket;
using CarPark.Application.ResponseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.IService
{
    public interface ITicketService
    {
        Task<Result<List<ParkingTicketDto>>> GetAllTicketsAsync();
    }
}
