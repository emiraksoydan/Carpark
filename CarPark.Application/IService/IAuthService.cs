using CarPark.Application.Dtos.Auth;
using CarPark.Application.ResponseData;
using CarPark.Domain.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.IService
{
    public interface IAuthService
    {
        Task<Result<CurrentUserDto>> LoginAsync(LoginRequestDto request);
    }
}
