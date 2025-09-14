using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Query.Models;

public class GetAllCourseDto : IRequest<Response>
{
    public int? Id { get; set; }
    public string? Cname { get; set; }
    public int? Hours { get; set; }
}