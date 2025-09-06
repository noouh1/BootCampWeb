namespace WebApplication1.Models;

public class Cart
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    
    public string UserId { get; set; }
    public Product Product { get; set; } 
    public int Quantity { get; set; } = 1;
    
    public ApplicationUser User { get; set; }
}