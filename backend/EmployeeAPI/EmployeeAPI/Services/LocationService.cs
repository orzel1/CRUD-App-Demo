using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;

namespace EmployeeAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly ZIIBDbContext _context;
        public LocationService(ZIIBDbContext context) 
        {
            _context = context;
        }

        public string[] getCitiesNames()
        {
            var result = _context.Locations.
                                Select(e => e.city)
                                .ToArray();
            return result;
        }
    }
}
