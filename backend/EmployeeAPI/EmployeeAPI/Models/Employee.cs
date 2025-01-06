using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    [Table("EMPLOYEES")]
    public class Employee
    {
        public required int employee_id { get; set; }
        public string? first_name { get; set; }
        public required string last_name { get; set; }
        public required string email { get; set; }
        public string? phone_number { get; set; }
        public required DateTime hire_date { get; set; }
        public required string job_id { get; set; }
        public decimal? salary { get; set; }
        public decimal? commission_pct { get; set; }
        public int? manager_id { get; set; }
        public int? department_id { get; set; }
    }
}
