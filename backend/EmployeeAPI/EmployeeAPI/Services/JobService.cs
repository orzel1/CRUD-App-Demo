using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;

namespace EmployeeAPI.Services
{
    public class JobService : IJobService
    {
        private readonly ZIIBDbContext _context;
        public JobService(ZIIBDbContext context) 
        {
            _context = context;
        }

        public string[] getJobsTitles()
        {
            var result = _context.Jobs
                                .Select(e => e.job_title)
                                .ToArray();
            return result;
        }
    }
}
