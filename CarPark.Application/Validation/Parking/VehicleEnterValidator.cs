using CarPark.Application.Dtos.Parking;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Validation.Parking
{
    public class VehicleEnterValidator : AbstractValidator<VehicleEnterRequestDto>
    {
        public VehicleEnterValidator()
        {
            RuleFor(x => x.Plate)
                .NotNull().WithMessage("Plaka alanı zorunludur.")
                .NotEmpty().WithMessage("Plaka boş olamaz.")
                .MaximumLength(10).WithMessage("Plaka en fazla 10 karakter olabilir.");
        }
    }
}
