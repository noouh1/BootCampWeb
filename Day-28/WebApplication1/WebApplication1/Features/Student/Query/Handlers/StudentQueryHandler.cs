using System.Net;
using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Global;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Student.Query.Handlers;

public class StudentQueryHandler(IStudentRepository _studentRepository,IMapper _mapper) :
    IRequestHandler<GetAllStudentDto, Response>,
    IRequestHandler<GetStudentByIdDto, Response>
{
    public async Task<Response> Handle(GetAllStudentDto request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAll();
        return new Response
        {
            StatusCode = HttpStatusCode.OK,
            Data = students,
            Message = "Students retrieved successfully",
            Status = true
        };
    }
    
    public async Task<Response> Handle(GetStudentByIdDto request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetById(request.Id);
        if (student == null)
        {
            return new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Student not found",
                Status = false
            };
        }
        
        return new Response
        {
            StatusCode = HttpStatusCode.OK,
            Data = student,
            Message = "Student retrieved successfully",
            Status = true
        };
    }
}