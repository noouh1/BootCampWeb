using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models.Products;
using Project.Domain.Responses;

namespace Project.Application.Features.CartItem.Commands.Delete;

public class DeleteCartItemCommandHandler(IRepository<Domain.Models.CartItem.CartItem> itemRepository) : ICommandHandler<DeleteCartItemCommand, Guid>
{
    public async Task<Response<Guid>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetByIdAsync(request.ItemId, cancellationToken);
        if (item is null)
        {
            return Response<Guid>.NotFound("item not found.");
        }

        await itemRepository.DeleteAsync(item, cancellationToken);
        return Response<Guid>.Success(request.ItemId);
    }
}