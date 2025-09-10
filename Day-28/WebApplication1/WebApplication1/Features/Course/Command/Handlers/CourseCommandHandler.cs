using System.Net;
using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Course.Command.Handlers;

public class CourseCommandHandler(ICourseRepository _courseRepository,IMapper _mapper) :
    IRequestHandler<CourseDto, Response>,
    IRequestHandler<UpdateCourseDto, Response>,
    IRequestHandler<DeleteCourseDto, Response>
{
    public async Task<Response> Handle(CourseDto request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<CourseEntity>(request);

        await _courseRepository.Create(course);

        return new Response
        {
            StatusCode = HttpStatusCode.OK,
            Data = course,
            Message = "Course created successfully",
            Status = true
        };
    }
    
    public async Task<Response> Handle(UpdateCourseDto request, CancellationToken cancellationToken)
    {
        var existingCourse = await _courseRepository.GetById(request.Id);
        if (existingCourse == null)
        {
            return new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Course not found",
                Status = false
            };
        }
        var newCourse = _mapper.Map(request, existingCourse);
        await _courseRepository.Update(newCourse);

        return new Response
        {
            StatusCode = HttpStatusCode.OK,
            Data = existingCourse,
            Message = "Course updated successfully",
            Status = true
        };
    }
    
    public async Task<Response> Handle(DeleteCourseDto request, CancellationToken cancellationToken)
    {
        var student = await _courseRepository.GetById(request.Id);
        if (student == null)
        {
            return new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = $"Course with id {request.Id} not found",
                Status = false,
            };
        }

        _courseRepository.Delete(student);


        return new Response
        {
            StatusCode = HttpStatusCode.NoContent,
            Message = "Course deleted successfully",
            Status = true
        };
    }
    
}