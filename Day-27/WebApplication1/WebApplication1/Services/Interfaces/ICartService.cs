using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces;

public interface ICartService
{
    Task<Response<CartDto>> AddToCart( int productId, int quantity, string userId);
    Task<Response<ICollection<CartDto>>> GetUserCart(string userId);
    Task<Response<List<Product>>> GetAllApprovedProducts();
}