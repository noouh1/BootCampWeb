using AutoMapper;
using Project.Application.Abstractions.Messaging;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Models;
using Project.Domain.Models.CartItem;
using Project.Domain.Responses;

namespace Project.Application.Features.CartItem.Commands.Add;

public class AddCartItemCommandHandler(IMapper mapper, IRepository<Domain.Models.CartItem.CartItem> itemrepository) : ICommandHandler<AddCartItemCommand, string>
{
    public async Task<Response<string>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var item = mapper.Map<Domain.Models.CartItem.CartItem>(request);
        await itemrepository.AddAsync(item, cancellationToken);
        return Response<string>.Success();
    }
}