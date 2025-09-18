using FluentValidation;

namespace Project.Application.Features.CartItem.Commands.Add;

public class AddCartItemCommandValidator : AbstractValidator<AddCartItemCommand>
{
    public AddCartItemCommandValidator()
    {
        RuleFor(c => c.CartId)
            .NotEmpty().WithMessage("Cart id is required.");
        RuleFor(c => c.ProductId)
            .NotEmpty().WithMessage("Product id is required.");

    }
    
}