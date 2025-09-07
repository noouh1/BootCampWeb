using System.Net;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Emails;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class EmailConfirmationService : IEmailConfirmationService
{
    private readonly IEmailService _emailService;
    private readonly IOtpStorage _otpStorage;
    public EmailConfirmationService(IEmailService emailService, IOtpStorage otpStorage)
    {
        _emailService = emailService;
        _otpStorage = otpStorage;
    }

    public EmailConfirmationService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task<Response<object>> SendConfirmationEmail(string email)
    {
        var otp = GenerateOtp();
        _otpStorage.Save(email, otp);

        var emailModel = new ConfirmEmailModel(
            ToName: "User",
            ToMail: email,
            Code: otp,
            Token: string.Empty,
            ExpiredInMinutes: 5
        );

        await _emailService.SendEmailAsync(emailModel, EmailSubject.ConfirmEmail, HtmlTemplate.ConfirmEmail);

        return new Response<object>
        {
            Message = "Confirmation email sent successfully",
            StatusCode = HttpStatusCode.OK
        };
    }

    public Task<Response<object>> VerifyOtp(string email, string otp)
    {
        if (_otpStorage.TryGet(email, out var storedOtp) && storedOtp == otp)
        {
            _otpStorage.Remove(email); 

            return Task.FromResult(new Response<object>
            {
                Message = "OTP verified successfully",
                StatusCode = HttpStatusCode.OK
            });
        }

        return Task.FromResult(new Response<object>
        {
            Message = "Invalid or expired OTP",
            StatusCode = HttpStatusCode.BadRequest
        });
    }

    private static string GenerateOtp()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }

}