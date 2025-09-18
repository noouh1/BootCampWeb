using FluentValidation;
using Project.Application.Features.Products.Commands.Update;
using Project.Domain.Models.Products;

namespace Project.Application.Features.CartItem.Commands.Update;

public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemCommand>
{
    public UpdateCartItemValidator()
    {
        RuleFor(p => p.Itemid)
            .NotEmpty().WithMessage("Item id is required.");


    }
    
}