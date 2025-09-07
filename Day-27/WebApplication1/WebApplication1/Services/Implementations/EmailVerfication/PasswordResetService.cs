using System.Net;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Emails;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class PasswordResetService : IPasswordResetService
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmailService _emailService;
        private readonly IOtpStorage _otpStorage;

        private static readonly Dictionary<string, PasswordResetSession> _sessions = new();

        public PasswordResetService(ApplicationDbContext db, IEmailService emailService, IOtpStorage otpStorage)
        {
            _db = db;
            _emailService = emailService;
            _otpStorage = otpStorage;
        }

        public async Task<Response<object>> ForgetPassword(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return new Response<object>
                {
                    Message = "Email not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var otp = GenerateOtp();
            _otpStorage.Save(email, otp);

            var emailModel = new ConfirmEmailModel(
                ToName: user.UserName ?? "User",
                ToMail: email,
                Code: otp,
                Token: string.Empty,
                ExpiredInMinutes: 5
            );

            await _emailService.SendEmailAsync(emailModel, EmailSubject.PasswordReset, HtmlTemplate.ConfirmEmail);

            return new Response<object>
            {
                Message = "OTP sent to email",
                StatusCode = HttpStatusCode.OK
            };
        }

        public Task<Response<PasswordResetSession>> VerifyOtp(string email, string otp)
        {
            if (_otpStorage.TryGet(email, out var storedOtp) && storedOtp == otp)
            {
                _otpStorage.Remove(email);

                var user = _db.Users.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return Task.FromResult(new Response<PasswordResetSession>
                    {
                        Message = "User not found",
                        StatusCode = HttpStatusCode.NotFound
                    });
                }

                var session = new PasswordResetSession
                {
                    UserId = user.Id,
                    Expiration = DateTime.UtcNow.AddMinutes(5)
                };
                _sessions[session.SessionId] = session;

                return Task.FromResult(new Response<PasswordResetSession>
                {
                    Data = session,
                    Message = "OTP verified. Use session to reset password.",
                    StatusCode = HttpStatusCode.OK
                });
            }

            return Task.FromResult(new Response<PasswordResetSession>
            {
                Message = "Invalid or expired OTP",
                StatusCode = HttpStatusCode.BadRequest
            });
        }

        public async Task<Response<object>> ChangePassword(string sessionId, string newPassword)
        {
            if (!_sessions.TryGetValue(sessionId, out var session) || session.Expiration < DateTime.UtcNow)
            {
                return new Response<object>
                {
                    Message = "Invalid or expired session",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var user = await _db.Users.FindAsync(session.UserId);
            if (user == null)
            {
                return new Response<object>
                {
                    Message = "User not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, newPassword);

            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            _sessions.Remove(sessionId); 

            return new Response<object>
            {
                Message = "Password changed successfully",
                StatusCode = HttpStatusCode.OK
            };
        }

        private static string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }