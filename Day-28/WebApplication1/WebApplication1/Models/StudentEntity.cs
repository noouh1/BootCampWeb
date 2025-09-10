using WebApplication1.Models.Base;

namespace WebApplication1.Models;

public class StudentEntity : BaseEntity
{
    public string Sname { get; set; }
    public int Age { get; set; }
    public ICollection<LearnEntity> Courses { get; set; }}