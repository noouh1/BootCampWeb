using System.Net;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Emails;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class PasswordResetService : IPasswordResetService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;


        public PasswordResetService(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<Response<object>> ForgetPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return new Response<object>
                {
                    Message = "Email not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var otp = GenerateOtp();
            var data = new EmailConfirmation()
            {
                Email = email,
                Otp = otp,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddMinutes(5)
            };
            await _context.AddAsync(data);
            await _context.SaveChangesAsync();

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

        public async Task<Response<PasswordResetSession>> VerifyOtp(string email, string otp)
        {

            var record = await _context.EmailConfirmations
                .FirstOrDefaultAsync(e => e.Email == email && e.Otp == otp);

            if (record == null)
            {
                return new Response<PasswordResetSession>
                {
                    Message = "Invalid or expired OTP",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            if (DateTime.UtcNow > record.ExpiredAt)
            {
                return new Response<PasswordResetSession>
                {
                    Message = "OTP has expired",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return new Response<PasswordResetSession>
                {
                    Message = "User not found",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var session = new PasswordResetSession
            {
                UserId = user.Id,
                Expiration = DateTime.UtcNow.AddMinutes(15) 
            };

            _context.PasswordResetSessions.Add(session);

            _context.EmailConfirmations.Remove(record);

            await _context.SaveChangesAsync();

            return new Response<PasswordResetSession>
            {
                Message = "OTP verified, session created",
                StatusCode = HttpStatusCode.OK,
                Data = session
            };
        }



        public async Task<Response<object>> ChangePassword(Guid sessionId, string newPassword)
        {
            var session = await _context.PasswordResetSessions
                .FirstOrDefaultAsync(s => s.SessionId == sessionId);

            if (session == null || DateTime.UtcNow > session.Expiration)
            {
                return new Response<object>
                {
                    Message = "Invalid or expired session",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == session.UserId);
            if (user == null)
            {
                return new Response<object>
                {
                    Message = "User not found",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, newPassword);
            
            _context.PasswordResetSessions.Remove(session);

            await _context.SaveChangesAsync();

            return new Response<object>
            {
                Message = "Password updated successfully",
                StatusCode = HttpStatusCode.OK
            };
        }

        private static string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }