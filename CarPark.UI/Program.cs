using CarPark.Application.Dtos.Auth;
using CarPark.Application.Dtos.Parking;
using CarPark.Application.IRepository;
using CarPark.Application.IService;
using CarPark.Infrastructure.Repository;
using CarPark.Infrastructure.Service;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews(options =>
    {
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    });

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<VehicleEnterRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestDto>();

builder.Services.AddAuthentication("ParkingCookie")
    .AddCookie("ParkingCookie", options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/Login";
    });


builder.Services.AddScoped<IParkingService, ParkingService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSingleton<IParkingSpotRepository, ParkingSpotRepository>();
builder.Services.AddSingleton<IParkingTicketRepository, ParkingTicketRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Parking}/{action=Index}/{id?}");

app.Run();
