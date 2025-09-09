using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Emails;
using WebApplication1.Dto;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class EmailConfirmationService : IEmailConfirmationService
{
    private readonly IEmailService _emailService;
    private readonly ApplicationDbContext _context;
    public EmailConfirmationService(IEmailService emailService, ApplicationDbContext context) 
    {
        _emailService = emailService;
        _context = context;
    }



    public async Task<Response<object>> SendConfirmationEmail(string email)
    {
        var otpentry = GenerateOtp();
        var data = new EmailConfirmation()
        {
            Email = email,
            Otp = otpentry,
            CreatedAt = DateTime.UtcNow,
            ExpiredAt = DateTime.UtcNow.AddMinutes(5)
        };
        await _context.AddAsync(data);
        await _context.SaveChangesAsync();

        var emailModel = new ConfirmEmailModel(
            ToName: "User",
            ToMail: email,
            Code: otpentry,
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

    public async Task<Response<object>> VerifyOtp(string email, string otp)
    {   
        var record = await _context.EmailConfirmations
            .FirstOrDefaultAsync(e => e.Email == email && e.Otp == otp);

        if (record == null)
        {
            return new Response<object>
            {
                Message = "Invalid or expired OTP",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        if (DateTime.UtcNow > record.ExpiredAt)
        {
            return new Response<object>
            {
                Message = "OTP has expired",
                StatusCode = HttpStatusCode.BadRequest
            };
        }
        _context.EmailConfirmations.Remove(record);
        await _context.SaveChangesAsync();
        
        return new Response<object>
        {
            Message = "Email verified successfully",
            StatusCode = HttpStatusCode.OK
        };

    }

    private static string GenerateOtp()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }

}