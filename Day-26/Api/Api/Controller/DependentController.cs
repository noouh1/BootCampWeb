using Api.Data;
using Api.Dto;
using Api.Interfaces;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class DependentController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Dependent> dependentRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDependent([FromForm]DependentDto dependentDto, CancellationToken cancellationToken)
    {
        var dependent = mapper.Map<Dependent>(dependentDto);
        dependentRepository.Add(dependent);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetDependentById), new { id = dependent.D_Id }, dependent);
    }

    [HttpGet]
    public IActionResult GetDependents([FromQuery]int pageSize = 10, [FromQuery]int pageNumber = 1)
    {
        if (pageSize <= 0 || pageNumber <= 0)
        {
            return BadRequest("pageSize and pageNumber must be greater than 0.");
        }

        var dependents = dependentRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok(dependents);
    }
    
    [HttpGet("get-by-id")]
    public IActionResult GetDependentById(int id)
    {
        var dependent = dependentRepository.GetById(id);
        if (dependent == null)
        {
            return NotFound();
        }
        return Ok(dependent);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteDependent(int id)
    {
        var dependent = dependentRepository.GetById(id);
        if (dependent == null)
        {
            return NotFound();
        }
        
        dependentRepository.Delete(dependent);
        context.SaveChanges();
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateDependent(int id, DependentDto updatedDependent)
    {
        var dependent = dependentRepository.GetById(id);
        if (dependent == null)
        {
            return NotFound();
        }
        
        var newDependent = mapper.Map(updatedDependent, dependent);
        dependentRepository.Update(newDependent);
        context.SaveChanges();
        
        return Ok(dependent);
    }
}