using CarPark.Application.Dtos.Parking.Request;
using FluentValidation;

namespace CarPark.Application.Validation.Parking
{
    public class VehiclerExitValidator : AbstractValidator<VehicleExitRequestDto>
    {
        public VehiclerExitValidator()
        {
            RuleFor(x => x.Plate)
                .NotEmpty().WithMessage("Plaka alanı  zorunlu.")
                .MaximumLength(10).WithMessage("Plaka en fazla 10 karakter olabilir.");
        }
    }
}
