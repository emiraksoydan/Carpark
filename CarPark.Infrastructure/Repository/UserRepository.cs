using CarPark.Application.IRepository;
using CarPark.Domain.Modals;
using CarPark.Infrastructure.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<User?> GetByUsernameAsync(string username) => Task.FromResult(
            InMemoryNonDb.Users.SingleOrDefault(x => x.Username == username)
        );

    }
}
