using CarPark.Application.Dtos.Parking.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Validation.Parking
{
    namespace CarPark.Application.Dtos.Parking
    {
        public class VehicleExitPaymentValidator : AbstractValidator<VehicleExitPayment>
        {
            public VehicleExitPaymentValidator()
            {
                RuleFor(x => x.Plate)
                    .NotEmpty().WithMessage("Plaka zorunludur.");

                RuleFor(x => x.CardHolderName)
                    .NotEmpty().WithMessage("Kart üzerindeki isim zorunludur.")
                    .MinimumLength(3).WithMessage("Kart üzerindeki isim en az 3 karakter olmalıdır.");

                RuleFor(x => x.CardNumber)
                    .NotEmpty().WithMessage("Kart numarası zorunludur.")
                    .Matches(@"^\d{4} \d{4} \d{4} \d{4}$")
                    .WithMessage("Kart numarası şu formatta olmalıdır: 1234 5678 9012 3456");

                RuleFor(x => x.Expiry)
                    .NotEmpty().WithMessage("Son kullanma tarihi zorunludur.")
                    .Matches(@"^(0[1-9]|1[0-2])\/\d{2}$")
                    .WithMessage("Son kullanma tarihi AA/YY formatında olmalıdır.");

                RuleFor(x => x.Cvv)
                    .NotEmpty().WithMessage("CVV zorunludur.")
                    .Matches(@"^\d{3}$").WithMessage("CVV 3  haneli olmalıdır.");
            }
        }
    }

}
