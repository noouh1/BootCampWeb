using Project.Application.Abstractions.Messaging;

namespace Project.Application.Features.CartItem.Commands.Update;

public record UpdateCartItemCommand(int Quantity ,Guid Itemid) : ICommand<Guid>;