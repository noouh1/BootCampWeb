using System.Net;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class AdminService(ApplicationDbContext _context) : IAdminService
{
    public async Task<Response<Product>> ApproveProduct(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product == null)
        {
            return new Response<Product>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Product not found"
            };
        }
        
        var exists = await _context.ApprovedProducts
            .AnyAsync(p => p.Id == productId);
        if (exists)
        {
            return new Response<Product>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Product already approved"
            };
        }
        
        var approvedProduct = new ApprovedProduct
        {
            ProductId = productId,
            Name = product.Name,
            
        };

        _context.ApprovedProducts.Add(approvedProduct);
        await _context.SaveChangesAsync();

        return new Response<Product>
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Product approved successfully"
        };
    }

   public async Task<Response<ICollection<Product>>> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();

        return new Response<ICollection<Product>>
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Data = products
        };
    }
}