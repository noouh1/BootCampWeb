namespace WebApplication1.Models.Emails;

public class EmailConfirmation
{
    public int id { get; set; }
    public string Email { get; set; }
    public string Otp { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiredAt { get; set; }    
}