using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models;

public class StudentDto : IRequest<Response>
{
    public string Sname { get; set; }
    public int Age { get; set; }
    
}