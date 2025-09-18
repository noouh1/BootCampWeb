using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Cart.Dtos;
using Project.Domain.Filters;
using Project.Domain.Responses;

namespace Project.Application.Features.Cart.Queries.GetAll;

public record GetAllCartQuery() : BaseFilter, IQuery<PaginatedResult<CartDto>>;
