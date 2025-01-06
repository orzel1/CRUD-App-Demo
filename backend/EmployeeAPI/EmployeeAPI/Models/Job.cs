using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    [Table("JOBS")]
    public class Job
    {
        public required int job_id { get; set; }
        public required string job_title { get; set; }
        public decimal? min_salary { get; set; }
        public decimal? max_salary { get; set; }
    }
}
