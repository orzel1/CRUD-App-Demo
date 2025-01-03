namespace EmployeeAPI.Models
{
    public class JobHistory
    {
        public required int employeeId { get; set; }
        public required DateTime startDate { get; set; }
        public required DateTime endDate { get; set; }
        public required string jobId { get; set; }
        public int? departmentId { get; set; }
    }
}
