using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Query.Models;

public class GetAllStudentDto : IRequest<Response>
{
    public int? id { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    
}