namespace Api.Models;

public class Employee
{
    public int E_Id { get; set; }             
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime Dob { get; set; }
    public DateTime Doj { get; set; }
    public string Gender { get; set; }
    public string? ImageUrl { get; set; }
    // Relations
    public int? DepartmentId { get; set; }   
    public virtual Department? Department { get; set; }
    public virtual Department DeptManager { get; set; }
    public virtual ICollection<WorksOn> WorksOnProjects { get; set; }
    public virtual ICollection<Dependent> Dependents { get; set; }
}