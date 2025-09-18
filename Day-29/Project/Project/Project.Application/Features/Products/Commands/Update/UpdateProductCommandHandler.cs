using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models.Products;
using Project.Domain.Responses;

namespace Project.Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler(IRepository<Product> productRepository) : ICommandHandler<UpdateProductCommand,Guid>
{
    public async Task<Response<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.id, cancellationToken);
        if (product is null)
        {
            return Response<Guid>.NotFound("Product not found.");
        }

        product.Name = request.name;
        await productRepository.UpdateAsync(product, cancellationToken);
        return Response<Guid>.Success(product.Id);
    }
    
}