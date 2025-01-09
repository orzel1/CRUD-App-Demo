using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Services;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Dtos;
using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.Profiles;

namespace EmployeeAPI.Controllers
{

    [Route("api/[controller]")] // Pobierz nazwe klasy jako adres endpointu
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        private readonly ICountryService _country;
        private readonly IDepartmentService _department;
        private readonly IJobService _job;
        private readonly ILocationService _location;
        private readonly IMapper _mapper;
        private readonly ZIIBDbContext _context;
        public EmployeeController(IEmployeeService employee, ICountryService country, IDepartmentService department, IJobService job, ILocationService location, IMapper mapper, ZIIBDbContext context) // Wstrzykiwanie zaleznosci
        {
            _employee = employee;
            _country = country;
            _department = department;
            _job = job;
            _location = location;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult GetEmployees() // api/employee - wysyla wszystkich pracownikow
        {
            var result = _employee.listAllEmployees();
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/[controller]/join")] // api/employee/join - wysyla polaczone tabele
        public ActionResult GetEmployeesJoin()
        {
            var result = _employee.listAllEmployeesJoin();
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/country/names")] // api/country/names - wysyla nazwy wszystkich krajow
        public ActionResult GetCountriesNames()
        {
            var result = _country.getCountriesNames();
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/department/names")] // api/department/names - wysyla wszystkie nazwy departamentow
        public ActionResult getDepartmentNames()
        {
            var result = _department.getDepartmentsNames();
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/job/titles")] // api/job/titles - wysyla wszystkie tytuly zawodowe
        public ActionResult getJobTitles()
        {
            var result = _job.getJobsTitles();
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/location/cities")] // api/location/cities - wysyla wszystkie nazwy miast
        public ActionResult GetLocationCities()
        {
            var result = _location.getCitiesNames();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]// api/employee/{id} - wysyla zadanie usuniecia zasobu employee o podanym id z serwera
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _employee.deleteEmployee(id);
            if (isDeleted)
            {
                return NoContent(); // Zwroc kod 200 operacja sie powiodla
            }
            else
            {
                return NotFound(); // Zwroc kod 404
            }
        }

        [HttpPost] // api/employee{body} - wyslanie danych nowego pracownika
        public ActionResult AddEmployee([FromBody] EmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // walidacja, ktora znajduje sie w EmployeeDto
            }
            var employee = _mapper.Map<Employee>(dto);

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{id}")] // api/employee{body} - wyslanie danych do modyfikacji
        public ActionResult UpdateEmployee([FromBody] EmployeeDto dto, [FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isUpdated = _employee.updateEmployee(id, dto);

            if(!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
