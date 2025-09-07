namespace WebApplication1.Models.Emails;

public class PasswordResetSession
{
    public string SessionId { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = string.Empty;
    public DateTime Expiration { get; set; } = DateTime.UtcNow.AddMinutes(5);
}