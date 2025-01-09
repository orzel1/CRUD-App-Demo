using EmployeeAPI.Profiles;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeeAPI.Dtos
{
    public class EmployeeDto
    {
        // DTO pozwala usunac niepotrzebne/wrazliwe dane z modeli tabel,
        // usunalem employee_id
        [MaxLength(20)]
        public string? first_name { get; set; }

        [MaxLength(25)]
        [Required]
        public required string last_name { get; set; }

        [Required]
        [MaxLength(25)]
        public required string email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? phone_number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public required DateTime hire_date { get; set; }

        [Required]
        [MaxLength(10)]
        public required string job_id { get; set; }

        [Range(-999999.99, 999999.99)]
        public decimal? salary { get; set; }

        [Range(-9.99, 9.99)]
        public decimal? commission_pct { get; set; }

        [Range(1, 999999)]
        public int? manager_id { get; set; }

        [Range(1, 9999)]
        public int? department_id { get; set; }
    }
}
