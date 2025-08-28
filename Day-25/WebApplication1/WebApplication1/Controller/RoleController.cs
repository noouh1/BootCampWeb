using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controller;
[ApiController]
[Route("api/[controller]")]
public class RoleController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = mapper.Map<Role>(roleDto);
        await context.Roles.AddAsync(role,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        if (role == null)
        {
            return NotFound();
        }
        var roledto = mapper.Map<RoleDto>(role);
        return Ok(roledto);
    }

    [HttpGet]
    public async Task<IActionResult> GetRole(CancellationToken cancellationToken)
    {
        var roles = await context.Roles.ToListAsync(cancellationToken);
        var roledtos = mapper.Map<List<RoleDto>>(roles);
        return Ok(roledtos);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRole(int id, CancellationToken cancellationToken)
    {
        var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        if (role == null)
        {
            return NotFound();
        }
        context.Roles.Remove(role);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateRole(int id , [FromBody] RoleDto UpdatedRole, CancellationToken cancellationToken)
    {
        var existingRole = await context.Roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        if (existingRole == null)
        {
            return NotFound();
        }
        var newRole = mapper.Map(UpdatedRole, existingRole);
        context.Roles.Update(newRole);
        await context.SaveChangesAsync(cancellationToken);
        return Ok(existingRole);
    }

    
}