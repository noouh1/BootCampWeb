using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Cart.Dtos;

namespace Project.Application.Features.Cart.Queries.GetById;

public record GetCartByIdQuery(Guid id) : IQuery<CartDto>;