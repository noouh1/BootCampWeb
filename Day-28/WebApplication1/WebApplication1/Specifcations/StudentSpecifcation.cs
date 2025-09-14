using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Models;
using WebApplication1.Specifcations.Base;

namespace WebApplication1.Specifcations;

public class StudentSpecifcation : BaseSpecification<StudentEntity>
{
    public StudentSpecifcation(GetAllStudentDto request)
    {
        // criteria
       if (!string.IsNullOrEmpty(request.Name))
       {
           Criterias.Add(p=> p.Sname.ToLower().Contains(request.Name.ToLower()));
       }
       if (request.Age.HasValue)
       {
              Criterias.Add(p=> p.Age == request.Age);
       }
       if (request.id.HasValue)
       {
              Criterias.Add(p=> p.Id == request.id.Value);
       }
       // include
       Includes.Add(p => p.Courses);
        // order by
        ApplyOrderByAsc(p=>p.Sname);
        // pagination
        ApplyPagination(0,10);
    }
    
}