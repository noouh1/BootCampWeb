using AutoMapper;
using Api.Dto;
using Api.Models;

namespace Api.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<EmployeeImageUrlResolver>());

            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());        }
    }
}