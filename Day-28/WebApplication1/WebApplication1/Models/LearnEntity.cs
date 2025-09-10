using WebApplication1.Models.Base;

namespace WebApplication1.Models;

public class LearnEntity : BaseEntity
{
    public int StudentId { get; set; }
    public virtual StudentEntity Student { get; set; }
    public int CourseId { get; set; }
    public virtual CourseEntity Course { get; set; }
}