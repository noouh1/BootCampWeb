using Project.Application.Abstractions.Messaging;

namespace Project.Application.Features.Categories.Commands.Update;

public record UpdateCategoryCommand(string name ,Guid id) : ICommand<Guid>;