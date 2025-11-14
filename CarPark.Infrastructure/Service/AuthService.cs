using CarPark.Application.Dtos.Auth.Reponse;
using CarPark.Application.Dtos.Auth.Request;
using CarPark.Application.IRepository;
using CarPark.Application.IService;
using CarPark.Application.ResponseData;


namespace CarPark.Infrastructure.Service
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<Result<CurrentUserDto>> LoginAsync(Login request)
        {
            var user = await _userRepo.GetByUsernameAsync(request.Username!);
            if (user == null)
                return Result<CurrentUserDto>.Fail("Kullanıcı adı hatalı");
            else if (user.Password != request.Password)
                return Result<CurrentUserDto>.Fail("Şifre hatalı");


            var dto = new CurrentUserDto
            {
                FullName = $"{user.FirstName} {user.LastName}"
            };

            return Result<CurrentUserDto>.Succeed(dto, "Giriş başarılı.");
        }
    }
}
