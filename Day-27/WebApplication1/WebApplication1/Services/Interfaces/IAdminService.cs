using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces;

public interface IAdminService
{
    Task<Response<Product>> ApproveProduct(int productId);
    Task<Response<ICollection<Product>>> GetAllProducts();
}