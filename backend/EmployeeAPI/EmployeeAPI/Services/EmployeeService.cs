using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.Dtos;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Dapper;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ICountryService _country;
        private readonly IDepartmentService _department;
        private readonly IJobService _job;
        private readonly ILocationService _location;
        private readonly ZIIBDbContext _context; // Zaleznosc bazy danych
        public EmployeeService(ZIIBDbContext context, ICountryService country, IDepartmentService department, IJobService job, ILocationService location)
        {
            _context = context; // Wstrzyknij zaleznosc pracy na danych z bazy danych
            _country = country;
            _department = department;
            _job = job;
            _location = location;
        }
        public IEnumerable<Employee> listAllEmployees()
        {
            return _context.Employees.ToList();
        }

public IEnumerable<EmployeeJoinDto> listAllEmployeesJoin()
    {
        using (IDbConnection db = new OracleConnection("User Id=ziibd44;Password=haslo2024;Data Source=155.158.112.45:1521/oltpstud"))
        {
            var query = @"
        SELECT E.EMPLOYEE_ID, E.FIRST_NAME, E.LAST_NAME, E.EMAIL, E.PHONE_NUMBER, E.HIRE_DATE, E.JOB_ID, E.SALARY, 
               E.COMMISSION_PCT, E.MANAGER_ID, E.DEPARTMENT_ID, D.DEPARTMENT_NAME, L.CITY, J.JOB_TITLE, 
               C.COUNTRY_NAME
        FROM EMPLOYEES E
        JOIN DEPARTMENTS D ON E.DEPARTMENT_ID = D.DEPARTMENT_ID
        JOIN LOCATIONS L ON D.LOCATION_ID = L.LOCATION_ID
        JOIN JOBS J ON E.JOB_ID = J.JOB_ID
        JOIN COUNTRIES C ON L.COUNTRY_ID = C.COUNTRY_ID";

            var results = db.Query<EmployeeJoinDto>(query).ToList();

            return results;
        }
    }

    public bool updateEmployee(int id, EmployeeDto dto)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw(
        "UPDATE EMPLOYEES SET FIRST_NAME = :FirstName, LAST_NAME = :LastName, " +
        "EMAIL = :Email, PHONE_NUMBER = :PhoneNumber, HIRE_DATE = :HireDate, " +
        "JOB_ID = :JobId, SALARY = :Salary, COMMISSION_PCT = :CommissionPct, " +
        "MANAGER_ID = :ManagerId, DEPARTMENT_ID = :DepartmentId " +
        "WHERE EMPLOYEE_ID = :id",
        new OracleParameter("FirstName", dto.first_name),
        new OracleParameter("LastName", dto.last_name),
        new OracleParameter("Email", dto.email),
        new OracleParameter("PhoneNumber", dto.phone_number),
        new OracleParameter("HireDate", dto.hire_date),
        new OracleParameter("JobId", dto.job_id),
        new OracleParameter("Salary", dto.salary),
        new OracleParameter("CommissionPct", dto.commission_pct),
        new OracleParameter("ManagerId", dto.manager_id),
        new OracleParameter("DepartmentId", dto.department_id),
        new OracleParameter("id", id));
            if (rowsAffected > 0)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool deleteEmployee(int id)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("DELETE FROM EMPLOYEES WHERE EMPLOYEE_ID = :id", new OracleParameter("id", id));
            if (rowsAffected == 0) 
            {
                return false;
            }
            _context.SaveChanges();
            return true;
        }

    }
}
