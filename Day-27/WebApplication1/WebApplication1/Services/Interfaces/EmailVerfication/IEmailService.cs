
using WebApplication1.Models.Emails;

namespace WebApplication1.Services.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(EmailModel emailModel, EmailSubject subject, HtmlTemplate htmlTemplate);
}
