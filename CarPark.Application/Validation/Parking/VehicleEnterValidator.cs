using CarPark.Application.Dtos.Parking.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Validation.Parking
{
    public class VehicleEnterValidator : AbstractValidator<VehicleEnter>
    {
        public VehicleEnterValidator()
        {
            RuleFor(x => x.Plate)
                .NotEmpty().WithMessage("Plaka zorunlu.")
                .MaximumLength(10).WithMessage("Plaka en fazla 10 karakter olabilir.");
            RuleFor(x => x.SpotId).NotEmpty().WithMessage("Lütfen Slot seçiniz");
        }
    }
}
