using Api.Data;
using Api.Dto;
using Api.Interfaces;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class ProjectController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Project> projectRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromForm]ProjectDto projectDto, CancellationToken cancellationToken)
    {
        var project = mapper.Map<Project>(projectDto);
        projectRepository.Add(project);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetProjectById), new { id = project.P_No }, project);
    }

    [HttpGet]
    public IActionResult GetProjects([FromQuery]int pageSize = 10, [FromQuery]int pageNumber = 1)
    {
        if (pageSize <= 0 || pageNumber <= 0)
        {
            return BadRequest("pageSize and pageNumber must be greater than 0.");
        }

        var projects = projectRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok(projects);
    }
    
    [HttpGet("get-by-id")]
    public IActionResult GetProjectById(int id)
    {
        var project = projectRepository.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProject(int id)
    {
        var project = projectRepository.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        
        projectRepository.Delete(project);
        context.SaveChanges();
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateProject(int id, ProjectDto updatedProject)
    {
        var project = projectRepository.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        
        var newProject = mapper.Map(updatedProject, project);
        projectRepository.Update(newProject);
        context.SaveChanges();
        
        return Ok(project);
    }
}