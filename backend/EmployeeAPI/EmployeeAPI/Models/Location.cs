namespace EmployeeAPI.Models
{
    public class Location
    {
        public required int locationId { get; set; }
        public string? streetAddress { get; set; }
        public string? postalCode { get; set; }
        public required string city { get; set; }
        public string? stateProvince { get; set; }
        public string? countryId { get; set; }

    }
}
