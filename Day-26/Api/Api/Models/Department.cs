namespace Api.Models;

public class Department
{
    public int D_No { get; set; }           
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Since { get; set; }
    
    // Relations
    public int? ManagerId { get; set; }     
    public virtual Employee? Manager { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<Project> Projects { get; set; }
}