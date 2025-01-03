namespace EmployeeAPI.Models
{
    public class Employee
    {
        public required int employeeId { get; set; }
        public string? firstName { get; set; }
        public required string lastName { get; set; }
        public required string email { get; set; }
        public string? phoneNumber { get; set; }
        public required DateTime hireDate { get; set; }
        public required int jobId { get; set; }
        public decimal? salary { get; set; }
        public decimal? commissionPct { get; set; }
        public int? managerId { get; set; }
        public int? departmentId { get; set; }
        public string? bonus { get; set; }
    }
}
