using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    [Table("LOCATIONS")]
    public class Location
    {
        public required int location_id { get; set; }
        public string? street_address { get; set; }
        public string? postal_code { get; set; }
        public required string city { get; set; }
        public string? state_province { get; set; }
        public string? country_id { get; set; }

    }
}
