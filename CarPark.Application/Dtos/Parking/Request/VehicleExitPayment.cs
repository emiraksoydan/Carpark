using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Dtos.Parking.Request
{
    public class VehicleExitPayment
    {
        public string Plate { get; set; } = default!;
        public string CardHolderName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public string Expiry { get; set; } = default!;
        public string Cvv { get; set; } = default!;
    }
}
