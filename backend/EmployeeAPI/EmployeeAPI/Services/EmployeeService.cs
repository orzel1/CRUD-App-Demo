using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ZIIBDbContext _dbContext; // Zaleznosc bazy danych
        public EmployeeService(ZIIBDbContext context)
        {
            _dbContext = context; // Gosciu wszczyknij mie to
        }

        public void addEmployee(Employee Employee)
        {

        }
        public IEnumerable<Employee> listEmployees()
        {
            IEnumerable<Employee> employees = new List<Employee>();
            employees = _dbContext.Employees.ToList();
            return employees;
        }
        public bool updateEmployee(Employee Employee)
        {
            return true;
        }
        public bool deleteEmployee(int employeeId)
        {
            return false;
        }
    }
}
