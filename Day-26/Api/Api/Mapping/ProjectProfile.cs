using Api.Dto;
using Api.Models;
using AutoMapper;

namespace Api.Mapping;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectDto, Project>();
    }
}