using Project.Application.Abstractions.Messaging;

namespace Project.Application.Features.Products.Commands.Update;

public record UpdateProductCommand(string name ,Guid id) : ICommand<Guid>;