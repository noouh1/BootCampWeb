using System.Net;
using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Student.Command.Handlers;

public class StudentCommandHandler(IStudentRepository _studentRepository,IMapper _mapper) :
    IRequestHandler<StudentDto, Response>,
    IRequestHandler<UpdateStudentDto, Response>,
    IRequestHandler<DeleteStudentDto, Response>
{
    public async Task<Response> Handle(StudentDto request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<StudentEntity>(request);

        await _studentRepository.Create(student);

        return new Response
        {
            StatusCode = HttpStatusCode.OK,
            Data = student,
            Message = "Student created successfully",
            Status = true
        };
    }
    
    public async Task<Response> Handle(UpdateStudentDto request, CancellationToken cancellationToken)
    {
        var existingStudent = await _studentRepository.GetById(request.Id);
        if (existingStudent == null)
        {
            return new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Student not found",
                Status = false
            };
        }
        var newStudent = _mapper.Map(request, existingStudent);
        await _studentRepository.Update(newStudent);

        return new Response
        {
            StatusCode = HttpStatusCode.OK,
            Data = existingStudent,
            Message = "Student updated successfully",
            Status = true
        };
    }
    
    public async Task<Response> Handle(DeleteStudentDto request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetById(request.Id);
        if (student == null)
        {
            return new Response
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = $"Student with id {request.Id} not found",
                Status = false,
            };
        }

        _studentRepository.Delete(student);


        return new Response
        {
            StatusCode = HttpStatusCode.NoContent,
            Message = "Student deleted successfully",
            Status = true
        };
    }
    
}