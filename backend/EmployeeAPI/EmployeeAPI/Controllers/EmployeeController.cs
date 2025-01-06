using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Services;
using EmployeeAPI.Interfaces;

namespace EmployeeAPI.Controllers
{

    [Route("[controller]")] // Pobierz nazwe klasy jako adres endpointu
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        private readonly ICountryService _country;
        private readonly IDepartmentService _department;
        private readonly IJobService _job;
        private readonly ILocationService _location;
        public EmployeeController(IEmployeeService employee, ICountryService country, IDepartmentService department, IJobService job, ILocationService location) // Wstrzykiwanie zaleznosci
        {
            _employee = employee;
            _country = country;
            _department = department;
            _job = job;
            _location = location;
        }

        [HttpGet]
        public IActionResult GetEmployees() // /employee - wysyla wszystkich pracownikow
        {
            var result = _employee.listAllEmployees();
            return Ok(result);
        }

        [HttpGet]
        [Route("/country/names")] // /country/names - wysyla nazwy wszystkich krajow
        public IActionResult GetCountriesNames()
        {
            var result = _country.getCountriesNames();
            return Ok(result);
        }

        [HttpGet]
        [Route("/department/names")] // /department/names - wysyla wszystkie nazwy departamentow
        public IActionResult getDepartmentNames()
        {
            var result = _department.getDepartmentsNames();
            return Ok(result);
        }

        [HttpGet]
        [Route("/job/titles")] // /job/titles - wysyla wszystkie tytuly zawodowe
        public IActionResult getJobTitles()
        {
            var result = _job.getJobsTitles();
            return Ok(result);
        }

        [HttpGet]
        [Route("/location/cities")] // /location/cities - wysyla wszystkie nazwy miast
        public IActionResult GetLocationCities()
        {
            var result = _location.getCitiesNames();
            return Ok(result);
        }
    }
}
