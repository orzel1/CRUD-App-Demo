namespace EmployeeAPI.Models
{
    public class Country
    {
        public required string countryId { get; set; }
        public string? countryName { get; set; }
        public int? regionId { get; set; }
    }
}
