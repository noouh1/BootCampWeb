namespace WebApplication1.Models.Emails.PasswordResset;

public class ChangePasswordDto
{
    public Guid SessionId { get; set; }
    public string NewPassword { get; set; }
}