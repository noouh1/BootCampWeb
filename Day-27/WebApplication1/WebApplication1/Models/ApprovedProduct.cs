namespace WebApplication1.Models;

public class ApprovedProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
}