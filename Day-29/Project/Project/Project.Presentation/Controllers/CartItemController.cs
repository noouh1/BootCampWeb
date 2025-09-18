using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CartItem.Commands.Add;
using Project.Application.Features.CartItem.Commands.Delete;
using Project.Application.Features.CartItem.Queries.GetAll;
using Project.Domain.Routes.BaseRouter;

namespace Project.Presentation.Controllers;

public class CartItemController : BaseController
{
    [HttpPost(Router.CartItemRoute.Add)]
    public async Task<IActionResult> Create(AddCartItemCommand cartCommand)
    {
        var result = await mediator.Send(cartCommand);
        return Result(result);
    }
    
    [HttpGet(Router.CartItemRoute.GetAll)]
    public async Task<IActionResult> GetAll(Guid ProductId,int Quantity)
    {
        var result = await mediator.Send(new GetAllCartItemQuery(ProductId,Quantity));
        return Result(result);
    }
    
    
    [HttpDelete(Router.CartItemRoute.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteCartItemCommand(id));
        return Result(result);
    }
    
}