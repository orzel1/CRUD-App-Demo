using EmployeeAPI.Data;
using EmployeeAPI.Services;
using EmployeeAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(); // Dodaj wszystkie kontrolery

var connectionString = builder.Configuration.GetConnectionString("ZIIBDatabase");

builder.Services.AddDbContext<ZIIBDbContext>(options => options.UseOracle(connectionString)); // Dodaj polaczenie z baza do apki

// Wstrzykiwanie zaleznosci do apki
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ILocationService, LocationService>();

var app = builder.Build(); // Buduj ten szajs

// Mapuj przekierowania z kontrolerow

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
