using AutoMapper;
using EmployeeAPI.Models;
using EmployeeAPI.Dtos;

namespace EmployeeAPI.Profiles
{
    public class EmployeeJoinProfile : Profile
    {
        public EmployeeJoinProfile()
        {
            CreateMap<(Employee, Department, Location, Job, Country), EmployeeJoinDto>()
                .ForMember(m => m.employee_id, c => c.MapFrom(s => s.Item1.employee_id))
                .ForMember(m => m.first_name, c => c.MapFrom(s => s.Item1.first_name))
                .ForMember(m => m.last_name, c => c.MapFrom(s => s.Item1.last_name))
                .ForMember(m => m.email, c => c.MapFrom(s => s.Item1.email))
                .ForMember(m => m.phone_number, c => c.MapFrom(s => s.Item1.phone_number))
                .ForMember(m => m.hire_date, c => c.MapFrom(s => s.Item1.hire_date))
                .ForMember(m => m.job_id, c => c.MapFrom(s => s.Item1.job_id))
                .ForMember(m => m.salary, c => c.MapFrom(s => s.Item1.salary))
                .ForMember(m => m.commission_pct, c => c.MapFrom(s => s.Item1.commission_pct))
                .ForMember(m => m.manager_id, c => c.MapFrom(s => s.Item1.manager_id))
                .ForMember(m => m.department_id, c => c.MapFrom(s => s.Item1.department_id))
                .ForMember(m => m.department_name, c => c.MapFrom(s => s.Item2.department_name))
                .ForMember(m => m.city, c => c.MapFrom(s => s.Item3.city))
                .ForMember(m => m.job_title, c => c.MapFrom(s => s.Item4.job_title))
                .ForMember(m => m.country_name, c => c.MapFrom(s => s.Item5.country_name));
        }
    }
}
