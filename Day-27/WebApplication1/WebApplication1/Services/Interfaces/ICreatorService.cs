using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces;

public interface ICreatorService
{
     Task<Response<ProductDto>> CreateProductAsync(ProductDto productDto);
     
}