using Api.Data;
using Api.Dto;
using Api.Interfaces;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class EmployeeController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Employee> employeeRepository,IFileUpload fileUpload) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromForm]EmployeeDto employeeDto, CancellationToken cancellationToken)
    {
        
        var employee = mapper.Map<Employee>(employeeDto);

        employeeRepository.Add(employee);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.E_Id }, employee);
    }

    [HttpGet]
    public IActionResult GetEmployees([FromQuery]int pageSize = 10, [FromQuery]int pageNumber = 1)
    {
        if (pageSize <= 0 || pageNumber <= 0)
        {
            return BadRequest("pageSize and pageNumber must be greater than 0.");
        }

        var employees = employeeRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        var employeedtos = mapper.Map<List<EmployeeDto>>(employees);
        return Ok(employeedtos);
    }
    
    [HttpGet("get-by-id")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        var employeeDto = mapper.Map<EmployeeDto>(employee);
        return Ok(employeeDto);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        
        employeeRepository.Delete(employee);
        context.SaveChanges();
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateEmployee(int id, EmployeeDto updatedEmployee)
    {
        var employee = employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        
        var newEmployee = mapper.Map(updatedEmployee, employee);
        employeeRepository.Update(newEmployee);
        context.SaveChanges();
        
        return Ok(employee);
    }
}