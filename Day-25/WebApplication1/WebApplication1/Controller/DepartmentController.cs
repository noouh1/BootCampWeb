using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controller;
[ApiController]
[Route("api/[controller]")]
public class DepartmentController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto departmentDto, CancellationToken cancellationToken)
    {
        var department = mapper.Map<Department>(departmentDto);
        await context.Departments.AddAsync(department,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var department = await context.Departments.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        if (department == null)
        {
            return NotFound();
        }
        var departmentDto = mapper.Map<DepartmentDto>(department);
        return Ok(departmentDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartment(CancellationToken cancellationToken)
    {
        var departments = await context.Departments.ToListAsync(cancellationToken);
        var departmentDtos = mapper.Map<List<DepartmentDto>>(departments);
        return Ok(departmentDtos);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDepartment(int id, CancellationToken cancellationToken)
    {
        var department = await context.Departments.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        if (department == null)
        {
            return NotFound();
        }
        context.Departments.Remove(department);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDepartment(int id , [FromBody] DepartmentDto UpdatedDepartment, CancellationToken cancellationToken)
    {
        var existingDepartment = await context.Departments.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        if (existingDepartment == null)
        {
            return NotFound();
        }
        var newDepartment = mapper.Map(UpdatedDepartment, existingDepartment);
        context.Departments.Update(newDepartment);
        await context.SaveChangesAsync(cancellationToken);
        return Ok(existingDepartment);
    }

    
}