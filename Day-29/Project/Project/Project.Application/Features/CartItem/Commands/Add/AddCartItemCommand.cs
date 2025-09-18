using Project.Application.Abstractions.Messaging;

namespace Project.Application.Features.CartItem.Commands.Add;

public record AddCartItemCommand(Guid ProductId,Guid CartId, int Quantity) : ICommand<string>;