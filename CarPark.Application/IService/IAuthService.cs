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
        Task<ServiceResult<User>> RegisterAsync( User user);
        Task<ServiceResult<User>> LoginAsync(User user);
        Task<ServiceResult<bool>> LogoutAsync();
    }
}
