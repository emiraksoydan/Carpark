using CarPark.Application.IService;
using CarPark.Application.ResponseData;
using CarPark.Domain.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        public Task<ServiceResult<User>> LoginAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<bool>> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<User>> RegisterAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
