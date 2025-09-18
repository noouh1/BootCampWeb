using Project.Application.Abstractions.Messaging;

namespace Project.Application.Features.Cart.Commands.Create;

public record CreateCartCommand() : ICommand<Guid>;
