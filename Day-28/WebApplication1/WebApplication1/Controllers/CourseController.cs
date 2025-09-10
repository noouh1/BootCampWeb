using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppMetaData.BaseRouter;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Features.Student.Query.Models;

namespace WebApplication1.Controllers;

public class CourseController : BaseController
{
    [HttpGet(Router.CourseRouter.Main)]
    public async Task<IActionResult> All([FromQuery] GetAllCourseDto request)
    {
        var result = await mediator.Send(request);
        return Result(result);
    }

    [HttpGet(Router.CourseRouter.MainId)] 
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetCourseByIdDto() { Id = id });
        return Result(result);
    }

    [HttpPost(Router.CourseRouter.Main)]
    public async Task<IActionResult> Create(CourseDto CourseDto)
    {
        var result = await mediator.Send(CourseDto);
        return Result(result);
    }

    [HttpPut(Router.CourseRouter.MainId)]
    public async Task<IActionResult> Update(UpdateCourseDto updateCourseDto)
    {
        var result = await mediator.Send(updateCourseDto);
        return Result(result);
    }

    [HttpDelete(Router.CourseRouter.MainId)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteCourseDto() { Id = id });
        return Result(result);
    }
}