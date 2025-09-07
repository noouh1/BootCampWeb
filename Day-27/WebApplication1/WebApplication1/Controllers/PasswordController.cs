using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Base;
using WebApplication1.Models;
using WebApplication1.Models.Emails;
using WebApplication1.Models.Emails.PasswordResset;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PasswordController : BaseController
{
    private readonly IPasswordResetService _passwordResetService;

    public PasswordController(IPasswordResetService passwordResetService)
    {
        _passwordResetService = passwordResetService;
    }

    [HttpPost("forget")]
    public async Task<IActionResult> ForgetPassword([FromBody] string email)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _passwordResetService.ForgetPassword(email);
        return Result(result);
    }

    [HttpPost("verify")]
    public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpModelDto dto)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _passwordResetService.VerifyOtp(dto.Email, dto.Otp);
        return Result(result);
    }

    [HttpPost("change")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _passwordResetService.ChangePassword(dto.SessionId, dto.NewPassword);
        return Result(result);
    }
}



