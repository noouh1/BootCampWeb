using Api.Data;
using Api.Dto;
using Api.Interfaces;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class DepartmentController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Department> departmentRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromForm]DepartmentDto departmentDto, CancellationToken cancellationToken)
    {
        var department = mapper.Map<Department>(departmentDto);
        
        
        departmentRepository.Add(department);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetDepartmentById), new { id = department.D_No }, department);
    }

    [HttpGet]
    public IActionResult GetDepartments([FromQuery]int pageSize = 10, [FromQuery]int pageNumber = 1)
    {
        if (pageSize <= 0 || pageNumber <= 0)
        {
            return BadRequest("pageSize and pageNumber must be greater than 0.");
        }

        var departments = departmentRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok(departmentRepository.GetAll());
    }
    
    [HttpGet("get-by-id")]
    public IActionResult GetDepartmentById(int id)
    {
        var department = departmentRepository.GetById(id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteDepartment(int id)
    {
        var department = departmentRepository.GetById(id);
        if (department == null)
        {
            return NotFound();
        }
        
        departmentRepository.Delete(department);
        context.SaveChanges();
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id, DepartmentDto updateddepartment)
    {
        var department = departmentRepository.GetById(id);
        if (department == null)
        {
            return NotFound();
        }
        
        var newdepartment = mapper.Map(updateddepartment, department);
        departmentRepository.Update(newdepartment);
        context.SaveChanges();
        
        return Ok(department);
    }
}