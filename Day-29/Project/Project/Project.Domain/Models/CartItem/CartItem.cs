using Project.Domain.Models.Base;
using Project.Domain.Models.Products;
namespace Project.Domain.Models.CartItem;

public class CartItem : Entity
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public Cart.Cart Cart { get; set; }
    public Product Product { get; set; }
}