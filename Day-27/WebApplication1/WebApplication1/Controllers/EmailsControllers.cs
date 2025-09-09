using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Base;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Models.Emails;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmailsControllers(IEmailConfirmationService _emailConfirmationService,ApplicationDbContext _context,IMapper _mapper) : BaseController
{
 
    [HttpPost("send-confirmation")]
    public async Task<IActionResult> SendConfirmation([FromQuery] string email)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }

        var result = await _emailConfirmationService.SendConfirmationEmail(email);
        return Result(result);
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromQuery] string email, [FromQuery] string otp)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _emailConfirmationService.VerifyOtp(email, otp);
        return StatusCode((int)result.StatusCode, result);
    }
}