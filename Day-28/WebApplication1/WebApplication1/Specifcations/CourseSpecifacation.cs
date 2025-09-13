using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Models;
using WebApplication1.Specifcations.Base;

namespace WebApplication1.Specifcations;

public class CourseSpecifacation : BaseSpecification<CourseEntity>
{
    public CourseSpecifacation(GetAllCourseDto request)
    {
        // criteria
        if (!string.IsNullOrEmpty(request.Cname))
        {
            Criterias.Add(p=> p.Cname.ToLower().Contains(request.Cname.ToLower()));
        }
        if (request.Hours.HasValue)
        {
            Criterias.Add(p=> p.Hours == request.Hours);
        }
        if (request.Id.HasValue)
        {
            Criterias.Add(p=> p.Id == request.Id.Value);
        }
        // include
        Includes.Add(p => p.Students);
        // order by
        ApplyOrderByAsc(p=>p.Cname);
        // pagination
        ApplyPagination(0,10);
    }
    
}