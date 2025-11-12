using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Domain.Modals
{
    public class ParkingSpot
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public bool IsFilled { get; set; }
    }
}
