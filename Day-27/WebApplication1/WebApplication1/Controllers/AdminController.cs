using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Base;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AdminController(IAdminService _adminService) : BaseController
{
    [Authorize(Roles = "Admin")]
    [HttpPost("approve/{productId}")]
    public async Task<IActionResult> ApproveProduct(int productId)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _adminService.ApproveProduct(productId);
        return StatusCode((int)result.StatusCode, result);
    }
    
    [Authorize(Roles = "Admin,Creator")]
    [HttpGet("all-products")]
    public async Task<IActionResult> GetAllProducts()
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _adminService.GetAllProducts();
        return StatusCode((int)result.StatusCode, result);
    }
}