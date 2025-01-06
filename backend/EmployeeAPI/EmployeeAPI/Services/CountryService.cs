using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly ZIIBDbContext _context;
        public CountryService(ZIIBDbContext context) 
        { 
            _context = context;
        }

        public string[] getCountriesNames()
        {
            var result = _context.Countries
                                    .Select(e => e.country_name)
                                    .ToArray();
            return result;
        }
    }
}
