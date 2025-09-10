using WebApplication1.Models.Base;

namespace WebApplication1.Models;

public class CourseEntity : BaseEntity
{
    public string Cname { get; set; }
    public int Hours { get; set; }
    public ICollection<LearnEntity> Students { get; set; }

    
}