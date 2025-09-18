using AutoMapper;
using Project.Application.Features.Cart.Commands.Create;
using Project.Application.Features.CartItem.Commands.Add;
using Project.Application.Features.CartItem.Dtos;

namespace Project.Application.Mapping.CartItem;

public class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        CreateMap<Domain.Models.CartItem.CartItem, CartItemDto>().ReverseMap();
        CreateMap<AddCartItemCommand, Domain.Models.CartItem.CartItem>();

    }
}