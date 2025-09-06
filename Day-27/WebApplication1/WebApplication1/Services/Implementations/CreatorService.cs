using System.Net;
using AutoMapper;
using WebApplication1.Helpers;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations;

public class CreatorService(ApplicationDbContext _context) : ICreatorService
{
    public async Task<Response<ProductDto>> CreateProductAsync(ProductDto model)
    {
        if (model == null || string.IsNullOrWhiteSpace(model.Name) || model.Price <= 0)
        {
            return new Response<ProductDto>
            {
                Message = "Invalid product data",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            CreatedAt = DateTime.Now
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return new Response<ProductDto>
        {
            Status = true,
            Data = model,
            Message = "Product created successfully",
            StatusCode = HttpStatusCode.Created
        };
    }
}