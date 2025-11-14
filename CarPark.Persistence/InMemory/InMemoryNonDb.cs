using CarPark.Domain.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Persistence.InMemory
{
    public static class InMemoryNonDb
    {
        public static List<ParkingSpot> Spots { get; } = new();
        public static List<ParkingTicket> Tickets { get; } = new();
        public static List<User> Users { get; } = new();

        static InMemoryNonDb()
        {
            for (int i = 1; i <= 20; i++)
            {
                Spots.Add(new ParkingSpot
                {
                    Id = i,
                    Code = $"A{i:1} : {i}",
                    IsFilled = false,

                });
            }
            Users.Add(new User
            {
                Id = 1,
                Username = "kullanıcı",
                Password = "password", 
                FirstName = "Emir",
                LastName = "Aksoydan"
            });
        }
    }
}

