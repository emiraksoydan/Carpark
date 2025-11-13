using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Domain.Modals
{
    public class ParkingTicket
    {
        public Guid Id { get; set; }
        public string Plate { get; set; } = null!;
        public int SpotId { get; set; }
        public DateTime EnteredAt { get; set; }
        public DateTime? ExitedAt { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
