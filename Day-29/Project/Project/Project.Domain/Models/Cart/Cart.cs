using Project.Domain.Models.Base;
using Project.Domain.Models.CartItem;

namespace Project.Domain.Models.Cart;

public class Cart : Entity
{
    public Guid UserId { get; set; }
    public ICollection<CartItem.CartItem> Items { get; set; }
    
}