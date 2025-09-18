using FluentValidation;
using Project.Domain.Models.Products;

namespace Project.Application.Features.Products.Commands.Update;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(ProductConstants.ProductNameMaxLengthValue).WithMessage(ProductConstants.ProductNameMaxLengthMessage);
        
    }
    
}