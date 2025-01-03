using EmployeeAPI.Data;
using EmployeeAPI.Services;
using EmployeeAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(); // Dodaj wszystkie kontrolery

var connectionString = builder.Configuration.GetConnectionString("ZIIBDatabase");

if (connectionString != null )
{
    Console.WriteLine("Polaczono z : " + connectionString);
}
else
{
    Console.WriteLine("Blad polaczenia z baza danych");
}

builder.Services.AddDbContext<ZIIBDbContext>(options => options.UseOracle(connectionString)); // Dodaj polaczenie z baza do apki

builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // wstrzykuj zaleznosc serwisu employee do apki

var app = builder.Build(); // Buduj ten szajs

// Mapuj przekierowania z kontrolerow

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
