using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Query.Models;

public class GetStudentByIdDto : IRequest<Response>
{
    public int Id { get; set; }
}