using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Cart.Dtos;
using Project.Application.Features.CartItem.Dtos;
using Project.Application.Features.CartItem.Specifications;
using Project.Domain.Responses;

namespace Project.Application.Features.CartItem.Queries.GetAll;

public class GetAllCartItemQueryHandler(IMapper mapper,IReadRepository<Domain.Models.CartItem.CartItem> repository) : IQueryHandler<GetAllCartItemQuery, PaginatedResult<CartItemDto>>
{
    public async Task<Response<PaginatedResult<CartItemDto>>> Handle(GetAllCartItemQuery request, CancellationToken cancellationToken)
    {
        var Cart = await repository
            .ListAsync(new CartItemSpec(
                request.PageSize, 
                request.PageNumber), cancellationToken);

        var CartCount = await repository
            .CountAsync(new CartItemSpec(
                request.PageSize,
                request.PageNumber), cancellationToken);
        
        var mappedCarts = mapper.Map<IEnumerable<CartItemDto>>(Cart);
        return Response<CartItemDto>.GetData(mappedCarts ,request.PageNumber, request.PageSize, CartCount);
    }
}