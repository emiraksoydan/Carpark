using CarPark.Application.Dtos.Parking;
using FluentValidation;

namespace CarPark.Application.Validation.Parking
{
    public class VehiclerExitValidator : AbstractValidator<VehicleExitRequestDto>
    {
        public VehiclerExitValidator()
        {
            RuleFor(x => x.Plate)
                .NotNull().WithMessage("Plaka alanı zorunludur.")
                .NotEmpty().WithMessage("Plaka boş olamaz.")
                .MaximumLength(10).WithMessage("Plaka en fazla 10 karakter olabilir.");
        }
    }
}
