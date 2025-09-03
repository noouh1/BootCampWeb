namespace Api.Dto;

public class EmployeeDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime Dob { get; set; }
    public DateTime Doj { get; set; }
    public string Gender { get; set; }
    public int? DepartmentId { get; set; }
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set; }

}
