using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Cart.Dtos;
using Project.Domain.Models.Products;
using Project.Domain.Responses;

namespace Project.Application.Features.Cart.Queries.GetById;

public class GetCartByIdQueryHandler(IMapper mapper, IReadRepository<Domain.Models.Cart.Cart> cartRepository)
    : IQueryHandler<GetCartByIdQuery, CartDto>
{
    public async Task<Response<CartDto>> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await cartRepository.GetByIdAsync(request.id, cancellationToken);
        if (cart is null)
            return Response<CartDto>.NotFound("Cart not found");
        var cartdto = mapper.Map<CartDto>(cart);
        return Response<CartDto>.Success(cartdto);
    }
}
    
