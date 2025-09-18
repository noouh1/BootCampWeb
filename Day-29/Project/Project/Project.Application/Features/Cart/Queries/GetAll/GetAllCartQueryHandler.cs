using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Cart.Dtos;
using Project.Application.Features.Cart.Specifications;
using Project.Domain.Responses;

namespace Project.Application.Features.Cart.Queries.GetAll;

public class GetAllCartQueryHandler(IMapper mapper,IReadRepository<Domain.Models.Cart.Cart> repository) : IQueryHandler<GetAllCartQuery, PaginatedResult<CartDto>>
{
    public async Task<Response<PaginatedResult<CartDto>>> Handle(GetAllCartQuery request, CancellationToken cancellationToken)
    {
        var Cart = await repository
            .ListAsync(new CartSpec(
                request.PageSize, 
                request.PageNumber), cancellationToken);

        var CartCount = await repository
            .CountAsync(new CartSpec(
                request.PageSize,
                request.PageNumber), cancellationToken);
        
        var mappedCart = mapper.Map<IEnumerable<CartDto>>(Cart);
        return Response<CartDto>.GetData(mappedCart ,request.PageNumber, request.PageSize, CartCount);
    }
}