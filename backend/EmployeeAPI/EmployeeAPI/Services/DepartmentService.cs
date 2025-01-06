using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;

namespace EmployeeAPI.Services
{
    public class DepartmentService :IDepartmentService
    {
        private readonly ZIIBDbContext _context;
        public DepartmentService(ZIIBDbContext context) 
        {
            _context = context;
        }

        public string[] getDepartmentsNames()
        {
            var result = _context.Departments
                                .Select(e => e.department_name)
                                .ToArray();
            return result;
        }
    }
}
