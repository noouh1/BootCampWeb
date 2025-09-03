using AutoMapper;
using Api.Dto;
using Api.Models;

namespace Api.Mapping;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<DepartmentDto, Department>().ReverseMap();
    }
}