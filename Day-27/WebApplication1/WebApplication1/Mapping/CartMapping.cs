using AutoMapper;

namespace WebApplication1.Mapping;

public class CartMapping : Profile
{
    public CartMapping()
    {
        CreateMap<Dto.CartDto, Models.Cart>().ReverseMap();
    }
    
}