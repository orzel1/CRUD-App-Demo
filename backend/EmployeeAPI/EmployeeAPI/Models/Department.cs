using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    [Table("DEPARTMENTS")]
    public class Department
    {
        public required int department_id { get; set; }
        public required string department_name { get; set; }
        public int? manager_id { get; set; }
        public int? location_id { get; set; }
    }
}
