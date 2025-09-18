using FluentValidation;
using Project.Application.Features.Products.Commands.Delete;

namespace Project.Application.Features.CartItem.Commands.Delete;

public class DeleteCartItemtValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteCartItemtValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Cart ID is required.");
    }
}