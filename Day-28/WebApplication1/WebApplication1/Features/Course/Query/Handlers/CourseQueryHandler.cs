using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Global;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Specifcations;

namespace WebApplication1.Features.Course.Query.Handlers;

public class CourseQueryHandler(IGenericRepository<CourseEntity> _courseRepository,IMapper _mapper) :
    IRequestHandler<GetAllCourseDto, Response>,
    IRequestHandler<GetCourseByIdDto, Response>
{
    public async Task<Response> Handle(GetAllCourseDto request, CancellationToken cancellationToken)
    {
        var Courses = await _courseRepository.GetTableAsNoTrackingWithSpec(new CourseSpecifacation(request))
            .ToListAsync(cancellationToken);
        return new Response
        {
            StatusCode = HttpStatusCode.OK,
            Data = Courses,
            Message = "Courses retrieved successfully",
            Status = true
        };
    }
    
    public async Task<Response> Handle(GetCourseByIdDto request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetById(request.Id);
        if (course == null)
        {
            return new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Course not found",
                Status = false
            };
        }
        
        return new Response
        {
            StatusCode = HttpStatusCode.OK,
            Data = course,
            Message = "Course retrieved successfully",
            Status = true
        };
    }
}