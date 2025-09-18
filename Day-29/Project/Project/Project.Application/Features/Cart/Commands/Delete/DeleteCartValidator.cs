using FluentValidation;

namespace Project.Application.Features.Cart.Commands.Delete;

public class DeleteCartValidator : AbstractValidator<DeleteCartCommand>
{
    public DeleteCartValidator()
    {
        RuleFor(x => x.id).NotEmpty().WithMessage("Cart Id is required.");
    }
}

