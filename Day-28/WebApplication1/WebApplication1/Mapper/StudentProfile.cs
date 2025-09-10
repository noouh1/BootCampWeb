using AutoMapper;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Models;

namespace WebApplication1.Mapper;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
         CreateMap<StudentDto, StudentEntity>().ReverseMap();
         CreateMap<UpdateStudentDto, StudentEntity>().ReverseMap();
    }
    
}