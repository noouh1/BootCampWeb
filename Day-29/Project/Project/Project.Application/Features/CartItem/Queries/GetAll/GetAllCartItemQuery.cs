using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Cart.Dtos;
using Project.Application.Features.CartItem.Dtos;
using Project.Domain.Filters;
using Project.Domain.Responses;

namespace Project.Application.Features.CartItem.Queries.GetAll;

public record GetAllCartItemQuery(Guid ProductId,int Quantity) : BaseFilter, IQuery<PaginatedResult<CartItemDto>>;
