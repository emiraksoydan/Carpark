using CarPark.Application.Dtos.Parking.Request;
using CarPark.Application.IService;
using CarPark.Infrastructure.Service;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace CarPark.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<VehicleEnter>();

            services.AddScoped<IParkingService, ParkingService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITicketService, TicketService>();

            return services;
        }
    }
}
