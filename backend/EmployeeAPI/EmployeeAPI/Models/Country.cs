using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    [Table("COUNTRIES")]
    public class Country
    {
        public required string country_id { get; set; }
        public string? country_name { get; set; }
        public int? region_id { get; set; }
    }
}
