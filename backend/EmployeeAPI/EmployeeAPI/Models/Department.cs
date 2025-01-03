namespace EmployeeAPI.Models
{
    public class Department
    {
        public required int departmentId { get; set; }
        public required string departmentName { get; set; }
        public int? managerId { get; set; }
        public int? locationId { get; set; }
    }
}
