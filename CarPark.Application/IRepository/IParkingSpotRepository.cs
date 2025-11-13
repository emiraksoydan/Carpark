using CarPark.Domain.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.IRepository
{
    public interface IParkingSpotRepository
    {
        Task<List<ParkingSpot>> GetAllAsync();
        Task<ParkingSpot> GetByIdAsync(int id);
        Task UpdateAsync(ParkingSpot spot);
    }
}
