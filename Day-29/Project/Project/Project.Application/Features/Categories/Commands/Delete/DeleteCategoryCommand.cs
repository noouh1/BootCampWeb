using Project.Application.Abstractions.Messaging;
using Project.Domain.Responses;

namespace Project.Application.Features.Categories.Commands.Delete;

public record DeleteCategoryCommand(Guid Id) : ICommand<Guid>;