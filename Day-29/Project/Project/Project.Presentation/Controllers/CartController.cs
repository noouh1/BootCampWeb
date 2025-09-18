using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Cart.Commands.Create;
using Project.Application.Features.Cart.Commands.Delete;
using Project.Application.Features.Cart.Queries.GetAll;
using Project.Domain.Routes.BaseRouter;

namespace Project.Presentation.Controllers;

public class CartController : BaseController
{
    [HttpPost(Router.CartRouter.Add)]
    public async Task<IActionResult> Create(CreateCartCommand cartCommand)
    {
        var result = await mediator.Send(cartCommand);
        return Result(result);
    }
    
    [HttpGet(Router.CartRouter.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllCartQuery());
        return Result(result);
    }
    
    [HttpGet(Router.CartRouter.GetById)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetAllCartQuery());
        return Result(result);
    }
    
    [HttpDelete(Router.CartRouter.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteCartCommand(id));
        return Result(result);
    }
}