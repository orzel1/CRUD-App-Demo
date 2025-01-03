using EmployeeAPI.Models;

namespace EmployeeAPI.Interfaces

{
    public interface IEmployeeService
    {
        public void addEmployee(Employee Employee);
        public IEnumerable<Employee> listEmployees();
        public bool updateEmployee(Employee Employee);
        public bool deleteEmployee(int employeeId);
    }
}
