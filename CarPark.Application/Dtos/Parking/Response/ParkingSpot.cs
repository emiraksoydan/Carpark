using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Dtos.Parking.Response
{
    public class ParkingSpotDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public bool IsFilled { get; set; }
        public string? Plate { get; set; }
        public DateTime? FilledAt { get; set; }
    }
}
