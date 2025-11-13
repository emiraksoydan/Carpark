using CarPark.Application.Dtos.Auth;
using FluentValidation;


namespace CarPark.Application.Validation.Login
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kullanıcı adı zorunlu.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre zorunlu.");
        }
    }
}
