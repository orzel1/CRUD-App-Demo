using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Services;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{

    [Route("api/[controller]")] // Pobierz nazwe klasy jako adres endpointu
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        public EmployeeController(IEmployeeService employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var result = _employee.listEmployees();
            if (result == null || !result.Any())
            {
                return NotFound("No employees found.");
            }
            return Ok(result);
        }

        // Testowy endpoint
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("Seima");
        }
    }
}
