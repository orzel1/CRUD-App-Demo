using EmployeeAPI.Models;

namespace EmployeeAPI.Interfaces

{
    public interface IEmployeeService
    {
        public void addEmployee(Employee Employee);
        public IEnumerable<Employee> listAllEmployees();
        public bool updateEmployee(int id);
        public bool deleteEmployee(int id);
    }
}
