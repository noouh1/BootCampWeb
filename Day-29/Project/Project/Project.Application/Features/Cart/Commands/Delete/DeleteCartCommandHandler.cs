using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Responses;


namespace Project.Application.Features.Cart.Commands.Delete;

public class DeleteCartCommandHandler(IMapper mapper,IRepository<Domain.Models.Cart.Cart> cartrepository) : ICommandHandler<DeleteCartCommand,Guid>
{
    public async Task<Response<Guid>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var Cart = await cartrepository.GetByIdAsync(request.id, cancellationToken);
        if (Cart is null)
        {
            return Response<Guid>.NotFound("Product not found.");
        }

        await cartrepository.DeleteAsync(Cart, cancellationToken);
        return Response<Guid>.Success(request.id);

        
    }
}