using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controller;
[ApiController]
[Route("api/[controller]")]
public class LoginController(ApplicationDbContext context, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLogin([FromBody] LoginDto loginDto, CancellationToken cancellationToken)
    {
        var login = mapper.Map<Login>(loginDto);
        await context.Logins.AddAsync(login,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = login.Id }, login);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var login = await context.Logins.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        if (login == null)
        {
            return NotFound();
        }

        var logindto = mapper.Map<LoginDto>(login);
        return Ok(logindto);
    }

    [HttpGet]
    public async Task<IActionResult> GetLogin(CancellationToken cancellationToken)
    {
        var logins = await context.Logins.ToListAsync(cancellationToken);
        var logindtos = mapper.Map<List<LoginDto>>(logins);
        return Ok(logindtos);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLogin(int id, CancellationToken cancellationToken)
    {
        var login = await context.Logins.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        if (login == null)
        {
            return NotFound();
        }
        context.Logins.Remove(login);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateLogin(int id , [FromBody] LoginDto UpdatedLogin, CancellationToken cancellationToken)
    {
        var existingLogin = await context.Logins.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        if (existingLogin == null)
        {
            return NotFound();
        }
        var newLogin = mapper.Map(UpdatedLogin, existingLogin);
        context.Logins.Update(newLogin);
        await context.SaveChangesAsync(cancellationToken);
        return Ok(existingLogin);
    }

}