using CarPark.Application.Dtos.Parking;
using CarPark.Application.IRepository;
using CarPark.Application.IService;
using CarPark.Infrastructure.Repository;
using CarPark.Infrastructure.Service;
using CarPark.Persistence.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace CarPark.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddSingleton<IParkingSpotRepository, ParkingSpotRepository>();
            services.AddSingleton<IParkingTicketRepository, ParkingTicketRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            return services;
        }
    }
}
