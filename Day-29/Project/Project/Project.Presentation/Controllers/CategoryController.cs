using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Categories.Commands.Add;
using Project.Application.Features.Categories.Commands.Delete;
using Project.Application.Features.Categories.Commands.Update;
using Project.Application.Features.Categories.Queries.GetAll;
using Project.Application.Features.Categories.Queries.GetById;
using Project.Domain.Routes.BaseRouter;

namespace Project.Presentation.Controllers;

public class CategoryController : BaseController
{
    [HttpPost(Router.CategoryRouter.Add)]
    public async Task<IActionResult> Create(AddCategoryCommand productCommand)
    {
        var result = await mediator.Send(productCommand);
        return Result(result);
    }
    
    [HttpPut(Router.CategoryRouter.Update)]
    public async Task<IActionResult> Update(Guid id, string name)
    {
        var result = await mediator.Send(new UpdateCategoryCommand(name, id));
        return Result(result);
    }
    
    [HttpDelete(Router.CategoryRouter.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    { 
        var result = await mediator.Send(new DeleteCategoryCommand(id));
        return Result(result);
    }
    
    [HttpGet(Router.CategoryRouter.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery]GetAllCategoriesQuery request)
    {
        var result = await mediator.Send(request);
        return Result(result);
    }
    
    [HttpGet(Router.CategoryRouter.GetById)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetCategoryByIdQuery(id));
        return Result(result);
    }
}