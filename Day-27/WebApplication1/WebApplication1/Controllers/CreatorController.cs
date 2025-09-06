using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Base;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CreatorController(ICreatorService _creatorService) : BaseController
{
    [Authorize(Roles = "Creator")]   
    [HttpPost]
    [Route("create-product")]
    public async Task<IActionResult> CreateProduct(ProductDto model)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _creatorService.CreateProductAsync(model);
        return Result(result);
    } 
}