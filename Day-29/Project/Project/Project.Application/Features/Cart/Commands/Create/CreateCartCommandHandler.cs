using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Responses;


namespace Project.Application.Features.Cart.Commands.Create;

public class CreateCartCommandHandler(IMapper mapper,IRepository<Domain.Models.Cart.Cart> cartrepository) : ICommandHandler<CreateCartCommand,Guid>
{
    public async Task<Response<Guid>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = mapper.Map<Domain.Models.Cart.Cart>(request);
        await cartrepository.AddAsync(cart, cancellationToken);
        return  Response<Guid>.Created(cart.Id);

        
    }
}