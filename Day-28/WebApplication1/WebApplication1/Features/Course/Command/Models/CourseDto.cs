using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models;

public class CourseDto : IRequest<Response>
{
    public string Cname { get; set; }
    public int Hours { get; set; }
    
}