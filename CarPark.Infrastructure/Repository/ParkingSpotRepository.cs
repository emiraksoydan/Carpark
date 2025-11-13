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
    public class ParkingSpotRepository : IParkingSpotRepository
    {
        public Task<List<ParkingSpot>> GetAllAsync()
        => Task.FromResult(InMemoryNonDb.Spots.ToList());

        public Task<ParkingSpot?> GetByIdAsync(int id)
            => Task.FromResult(InMemoryNonDb.Spots.SingleOrDefault(x => x.Id == id));

        public Task UpdateAsync(ParkingSpot spot)
        {
            return Task.CompletedTask;
        }
    }
}
