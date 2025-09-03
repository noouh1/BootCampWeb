using Api.Dto;
using Api.Models;
using AutoMapper;

namespace Api.Mapping;

public class DependentProfile : Profile
{
    public DependentProfile()
    {
        CreateMap<DependentDto, Dependent>();
    }
}