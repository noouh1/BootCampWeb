using WebApplication1.Models;
using WebApplication1.Models.Emails;

namespace WebApplication1.Services.Interfaces;

public interface IPasswordResetService
{
    Task<Response<object>> ForgetPassword(string email);
    Task<Response<PasswordResetSession>> VerifyOtp(string email, string otp);
    Task<Response<object>> ChangePassword(string sessionId, string newPassword);
}