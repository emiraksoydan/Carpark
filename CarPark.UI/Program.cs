using CarPark.Application.Dtos.Auth;
using CarPark.Application.Dtos.Parking;
using CarPark.Application.IRepository;
using CarPark.Application.IService;
using CarPark.Infrastructure;
using CarPark.Infrastructure.Repository;
using CarPark.Infrastructure.Service;
using CarPark.Persistence;
using CarPark.Persistence.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews(options =>
    {
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    });

builder.Services.AddInfrastructureLayer();
builder.Services.AddPersistenceLayer();
builder.Services.AddAuthentication("ParkingCookie")
    .AddCookie("ParkingCookie", options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/Login";
    });




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
    pattern: "{controller=Parking}/{action=Index}");

app.Run();
