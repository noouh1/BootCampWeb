﻿namespace WebApplication1.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int? DepartmentId { get; set; }
    public int? RoleId { get; set; }

    public virtual Department Department { get; set; }
    public virtual Role Role { get; set; }
    public virtual Login Login { get; set; }
}