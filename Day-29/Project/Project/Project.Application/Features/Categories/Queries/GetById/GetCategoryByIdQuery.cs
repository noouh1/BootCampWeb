using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Categories.Dtos;

namespace Project.Application.Features.Categories.Queries.GetById;

public record GetCategoryByIdQuery(Guid Id) : IQuery<CategoryDto>;