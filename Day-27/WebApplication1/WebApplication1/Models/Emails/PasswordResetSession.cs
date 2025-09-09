using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Emails;

public class PasswordResetSession
{
    [Key]
    public Guid SessionId { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public DateTime Expiration { get; set; } = DateTime.UtcNow.AddMinutes(5);
    
    
}