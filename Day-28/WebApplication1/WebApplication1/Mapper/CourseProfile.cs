using AutoMapper;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Models;

namespace WebApplication1.Mapper;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDto, CourseEntity>().ReverseMap();
        CreateMap<UpdateCourseDto, CourseEntity>().ReverseMap();
    }
}