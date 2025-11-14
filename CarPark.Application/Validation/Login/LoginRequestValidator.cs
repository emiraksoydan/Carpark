using CarPark.Application.Dtos.Auth.Request;
using FluentValidation;


namespace CarPark.Application.Validation.Login
{
    public class LoginRequestValidator : AbstractValidator<Dtos.Auth.Request.Login>
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
