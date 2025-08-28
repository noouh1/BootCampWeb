using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controller;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto employeeDto, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Employee>(employeeDto);
        await context.Employees.AddAsync(employee,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEmployee(CancellationToken cancellationToken)
    {
        var employees = await context.Employees.ToListAsync(cancellationToken);
        return Ok(employees);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id, CancellationToken cancellationToken)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (employee == null)
        {
            return NotFound();
        }
        context.Employees.Remove(employee);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id , [FromBody] EmployeeDto UpdatedEmployee, CancellationToken cancellationToken)
    {
        var existingEmployee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (existingEmployee == null)
        {
            return NotFound();
        }
        var newEmployee = mapper.Map(UpdatedEmployee, existingEmployee);
        context.Employees.Update(newEmployee);
        await context.SaveChangesAsync(cancellationToken);
        return Ok(existingEmployee);
    }
}