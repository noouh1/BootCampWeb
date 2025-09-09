using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces;

public interface IEmailConfirmationService
{
    Task<Response<object>> SendConfirmationEmail(string email);
    Task<Response<object>> VerifyOtp(string email, string otp);
}