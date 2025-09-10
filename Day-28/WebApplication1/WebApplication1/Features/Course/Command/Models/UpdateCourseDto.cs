using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models;

public class UpdateCourseDto : IRequest<Response>
{
    public int Id { get; set; }
    
}