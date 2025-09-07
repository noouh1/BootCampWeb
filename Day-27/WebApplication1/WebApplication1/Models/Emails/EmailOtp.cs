namespace WebApplication1.Models.Emails;

public class EmailOtp
{
    public int Id { get; set; }
    public string UserId { get; set; } 
    public string Code { get; set; }     
    public DateTime ExpiryTime { get; set; } 
    public bool IsUsed { get; set; } = false;
}