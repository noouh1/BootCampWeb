using Project.Application.Abstractions.Messaging;
using Project.Domain.Responses;

namespace Project.Application.Features.CartItem.Commands.Delete;

public record DeleteCartItemCommand(Guid ItemId) : ICommand<Guid>;