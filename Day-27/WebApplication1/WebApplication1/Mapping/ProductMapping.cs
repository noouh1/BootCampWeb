using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.imageUrl, opt => opt.MapFrom<ProductResolveUrl>());

        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.imageUrl, opt => opt.Ignore());
    }
}