namespace Api.Dto;

public class DepartmentDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Since { get; set; }
    public int? ManagerId { get; set; }
    
}