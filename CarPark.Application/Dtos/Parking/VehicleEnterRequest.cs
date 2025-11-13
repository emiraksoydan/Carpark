using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Dtos.Parking
{
    public class VehicleEnterRequestDto
    {
        public int SpotId { get; set; }
        public string? Plate { get; set; }
    }
}
