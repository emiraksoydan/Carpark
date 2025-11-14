using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Dtos.Parking.Request
{
    public class VehicleEnter
    {
        public int SpotId { get; set; } = default!;
        public string Plate { get; set; } = default!;
    }
}
