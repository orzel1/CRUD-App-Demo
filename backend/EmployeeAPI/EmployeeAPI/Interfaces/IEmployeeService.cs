using EmployeeAPI.Dtos;
using EmployeeAPI.Models;

namespace EmployeeAPI.Interfaces

{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> listAllEmployees();
        public IEnumerable<EmployeeJoinDto> listAllEmployeesJoin();
        public bool updateEmployee(int id, EmployeeDto dto);
        public bool deleteEmployee(int id);
    }
}
