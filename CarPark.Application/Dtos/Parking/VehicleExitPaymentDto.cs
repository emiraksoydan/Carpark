using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Dtos.Parking
{
    public class VehicleExitPaymentDto
    {
        public string? Plate { get; set; }

        public string? CardHolderName { get; set; }
        public string? CardNumber { get; set; }
        public string? Expiry { get; set; }
        public string? Cvv { get; set; } 
    }
}
