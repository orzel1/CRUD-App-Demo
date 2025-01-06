using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Data
{
    public class ZIIBDbContext : DbContext
    {
        public ZIIBDbContext(DbContextOptions<ZIIBDbContext> options) : base(options)
            {
            }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Definicja kluczy glownych
            modelBuilder.Entity<Country>()
                .HasKey(e => e.country_id);

            modelBuilder.Entity<Department>()
                .HasKey(e => e.department_id);

            modelBuilder.Entity<Job>()
                .HasKey(e => e.job_id);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.employee_id);

            modelBuilder.Entity<Location>()
                .HasKey(e => e.location_id);

            // Asp.net wysyla zapytanie poslugujac sie nazwami zmiennych z klas modelowych, w naszym przypadku musimy uzyc nazw bezposrednio z bazy danych ziibd
            // Employees

            modelBuilder.Entity<Employee>()
                .Property(e => e.employee_id)
                .HasColumnName("EMPLOYEE_ID")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.first_name)
                .HasColumnName("FIRST_NAME")
                .IsRequired(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.last_name)
                .HasColumnName("LAST_NAME")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.email)
                .HasColumnName("EMAIL")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.phone_number)
                .HasColumnName("PHONE_NUMBER")
                .IsRequired(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.hire_date)
                .HasColumnName("HIRE_DATE")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.job_id)
                .HasColumnName("JOB_ID")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.salary)
                .HasColumnName("SALARY")
                .IsRequired(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.commission_pct)
                .HasColumnName("COMMISSION_PCT")
                .IsRequired(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.manager_id)
                .HasColumnName("MANAGER_ID")
                .IsRequired(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.department_id)
                .HasColumnName("DEPARTMENT_ID")
                .IsRequired(false);

            // Reszta (Wyszukuje tylko pojedyncze kolumny z bazy danych, dlatego nie deklaruje reszty kolumn:

            modelBuilder.Entity<Country>() // Country
                .Property(e => e.country_name)
                .HasColumnName("COUNTRY_NAME")
                .IsRequired(false);

            modelBuilder.Entity<Department>() // Department
                .Property(e => e.department_name)
                .HasColumnName("DEPARTMENT_NAME")
                .IsRequired();

            modelBuilder.Entity<Job>() // Job
                .Property(e => e.job_title)
                .HasColumnName("JOB_TITLE")
                .IsRequired();

            modelBuilder.Entity<Location>() // Location
                .Property(e => e.city)
                .HasColumnName("CITY")
                .IsRequired();
        }
    }
       
}
