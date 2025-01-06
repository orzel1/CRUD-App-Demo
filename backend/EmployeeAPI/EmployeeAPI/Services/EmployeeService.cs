using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ZIIBDbContext _dbContext; // Zaleznosc bazy danych
        public EmployeeService(ZIIBDbContext context)
        {
            _dbContext = context; // Wstrzyknij zaleznosc pracy na danych z bazy danych
        }

        public void addEmployee(Employee Employee)
        {

        }
        public IEnumerable<Employee> listAllEmployees()
        {
            IEnumerable<Employee> employees = new List<Employee>();
            employees = _dbContext.Employees.ToList();
            return employees;
        }
        public bool updateEmployee(int id)
        {
            return true;
        }
        public bool deleteEmployee(int id)
        {
            return false;
        }

    }
}
