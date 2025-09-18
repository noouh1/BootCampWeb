using FluentValidation;

namespace Project.Application.Features.Cart.Queries.GetById;

public class GetCartByIdValidator : AbstractValidator<GetCartByIdQuery>
{
    public GetCartByIdValidator()
    {
        RuleFor(x => x.id).NotEmpty().WithMessage("Cart Id is required.");
    }
}