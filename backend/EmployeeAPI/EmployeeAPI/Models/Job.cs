namespace EmployeeAPI.Models
{
    public class Job
    {
        public required int jobId { get; set; }
        public required string jobTitle { get; set; }
        public decimal? minSalary { get; set; }
        public decimal? maxSalary { get; set; }
    }
}
