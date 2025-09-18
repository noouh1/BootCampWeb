using AutoMapper;
using Project.Application.Features.Cart.Commands.Create;
using Project.Application.Features.Cart.Dtos;

namespace Project.Application.Mapping.Cart;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<CartDto, Domain.Models.Cart.Cart>().ReverseMap();
        CreateMap<CreateCartCommand, Domain.Models.Cart.Cart>();

    }
}