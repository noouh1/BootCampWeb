using FluentValidation;

namespace Project.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Category ID is required.");
    }
}