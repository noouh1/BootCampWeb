using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class CartService(ApplicationDbContext _context,IMapper _mapper) : ICartService
{
    public async Task<Response<CartDto>> AddToCart(int productId, int quantity, string userId)
    {

        var existingItem = await _context.Carts
            .FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.UserId == userId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var cartItem = new Cart()
            {
                ProductId = productId,
                UserId = userId,
                Quantity = quantity
            };
            _context.Carts.Add(cartItem);
        }

        await _context.SaveChangesAsync();

        var cartItemDto = await _context.Carts
            .Include(ci => ci.Product)
            .Where(ci => ci.ProductId == productId && ci.UserId == userId)
            .Select(ci => _mapper.Map<CartDto>(ci))
            .FirstOrDefaultAsync();

        return new Response<CartDto>
        {
            Status = true,
            Data = cartItemDto,
            Message = "Product added to cart successfully",
            StatusCode = HttpStatusCode.Created
        };
    }

    public async Task<Response<ICollection<CartDto>>> GetUserCart(string userId)
    {
        var cartItems = await _context.Carts
            .Where(ci => ci.UserId == userId)
            .ToListAsync();

        var cartItemDtos = _mapper.Map<ICollection<CartDto>>(cartItems);

        return new Response<ICollection<CartDto>>
        {
            Status = true,
            Data = cartItemDtos,
            Message = "Cart items retrieved successfully",
            StatusCode = HttpStatusCode.OK
        };
    }

    
    public async Task<Response<List<Product>>> GetAllApprovedProducts()
    {
        var approvedProducts = await _context.ApprovedProducts
            .Include(ap => ap.Product)
            .Select(ap => ap.Product)
            .ToListAsync();

        return new Response<List<Product>>
        {
            StatusCode = HttpStatusCode.OK,
            Data = approvedProducts
        };
    }

}