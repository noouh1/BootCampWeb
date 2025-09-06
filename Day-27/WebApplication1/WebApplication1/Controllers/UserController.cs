using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Base;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers;

public class UserController(ICartService _cartService,UserManager<ApplicationUser> _userManager) : BaseController
{   [Authorize(Roles = "User")]
    [HttpPost("add")]
    public async Task<IActionResult> AddToCart([FromBody] CartDto model)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await _cartService.AddToCart(model.ProductId, model.Quantity, userId);
        return Result(result);
    }
    
    [Authorize(Roles = "User")]
    [HttpGet("mycart")]
    public async Task<IActionResult> GetUserCart()
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await _cartService.GetUserCart(userId);
        return Result(result);
    }
    [Authorize(Roles = "User")]
    [HttpGet("approved-products")]
    public async Task<IActionResult> GetApprovedProducts()
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        
        var result = await _cartService.GetAllApprovedProducts();
        return Result(result);
    }
}