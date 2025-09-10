using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models;

public class DeleteCourseDto : IRequest<Response>
{
    public int Id { get; set; }
    
}