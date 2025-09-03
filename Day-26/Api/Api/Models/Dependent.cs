namespace Api.Models;

public class Dependent
{
    public int D_Id { get; set; }          
    public string D_Name { get; set; }
    public string Gender { get; set; }
    public string Relationship { get; set; }

    // Relation
    public int? EmployeeId { get; set; }     
    public virtual Employee Employee { get; set; }
}