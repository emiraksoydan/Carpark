using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Dtos.Ticket.Response
{
    public class ParkingTicket
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public string? SpotCode { get; set; }
        public DateTime EnteredAt { get; set; }
        public DateTime? ExitedAt { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
