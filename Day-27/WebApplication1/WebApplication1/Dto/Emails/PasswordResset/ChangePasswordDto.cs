namespace WebApplication1.Models.Emails.PasswordResset;

public class ChangePasswordDto
{
    public string SessionId { get; set; }
    public string NewPassword { get; set; }
}