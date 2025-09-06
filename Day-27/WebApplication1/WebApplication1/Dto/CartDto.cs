namespace WebApplication1.Dto;

public class CartDto
{
    public int ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int Quantity { get; set; }
    public string UserId { get; set; }
}