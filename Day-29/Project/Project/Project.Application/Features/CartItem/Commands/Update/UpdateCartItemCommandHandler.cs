using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Application.Features.Products.Commands.Update;
using Project.Domain.Models.Products;
using Project.Domain.Responses;

namespace Project.Application.Features.CartItem.Commands.Update;

public class UpdateCartItemCommandHandler(IRepository<Domain.Models.CartItem.CartItem> itemRepository) : ICommandHandler<UpdateCartItemCommand,Guid>
{
    public async Task<Response<Guid>> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetByIdAsync(request.Itemid, cancellationToken);
        if (item is null)
        {
            return Response<Guid>.NotFound("item not found.");
        }

        item.Quantity = request.Quantity;
        await itemRepository.UpdateAsync(item, cancellationToken);
        return Response<Guid>.Success(item.CartId);
    }
    
}