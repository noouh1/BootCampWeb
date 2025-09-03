namespace Api.Models;

public class Project
{
    public int P_No { get; set; }           
    public string Name { get; set; }
    public string Location { get; set; }

    // Relations
    public int? DepartmentId { get; set; }   
    public virtual Department Department { get; set; }

    public virtual ICollection<WorksOn> Employees { get; set; }
}