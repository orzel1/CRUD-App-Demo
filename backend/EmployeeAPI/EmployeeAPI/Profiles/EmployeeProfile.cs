using AutoMapper;
using EmployeeAPI.Models;
using EmployeeAPI.Dtos;

namespace EmployeeAPI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>() // Mapowanie Employee => EmployeeDto
                .ForMember(m => m.first_name, c => c.MapFrom(s => s.first_name))
                .ForMember(m => m.last_name, c => c.MapFrom(s => s.last_name))
                .ForMember(m => m.email, c => c.MapFrom(s => s.email))
                .ForMember(m => m.phone_number, c => c.MapFrom(s => s.phone_number))
                .ForMember(m => m.hire_date, c => c.MapFrom(s => s.hire_date))
                .ForMember(m => m.job_id, c => c.MapFrom(s => s.job_id))
                .ForMember(m => m.salary, c => c.MapFrom(s => s.salary))
                .ForMember(m => m.commission_pct, c => c.MapFrom(s => s.commission_pct))
                .ForMember(m => m.manager_id, c => c.MapFrom(s => s.manager_id))
                .ForMember(m => m.department_id, c => c.MapFrom(s => s.department_id));

            CreateMap<EmployeeDto, Employee>() // Mapowanie EmployeeDto => Employee
                .ForMember(m => m.first_name, c => c.MapFrom(s => s.first_name))
                .ForMember(m => m.last_name, c => c.MapFrom(s => s.last_name))
                .ForMember(m => m.email, c => c.MapFrom(s => s.email))
                .ForMember(m => m.phone_number, c => c.MapFrom(s => s.phone_number))
                .ForMember(m => m.hire_date, c => c.MapFrom(s => s.hire_date))
                .ForMember(m => m.job_id, c => c.MapFrom(s => s.job_id))
                .ForMember(m => m.salary, c => c.MapFrom(s => s.salary))
                .ForMember(m => m.commission_pct, c => c.MapFrom(s => s.commission_pct))
                .ForMember(m => m.manager_id, c => c.MapFrom(s => s.manager_id))
                .ForMember(m => m.department_id, c => c.MapFrom(s => s.department_id));
        }
    }
}
