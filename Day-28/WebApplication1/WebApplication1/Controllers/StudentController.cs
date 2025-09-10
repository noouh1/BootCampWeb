using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppMetaData.BaseRouter;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Features.Student.Query.Models;

namespace WebApplication1.Controllers;

public class StudentController : BaseController
{
    [HttpGet(Router.StudentRouter.Main)]
    public async Task<IActionResult> All([FromQuery] GetAllStudentDto request)
    {
        var result = await mediator.Send(request);
        return Result(result);
    }

    [HttpGet(Router.StudentRouter.MainId)] 
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetStudentByIdDto() { Id = id });
        return Result(result);
    }

    [HttpPost(Router.StudentRouter.Main)]
    public async Task<IActionResult> Create(StudentDto studentDto)
    {
        var result = await mediator.Send(studentDto);
        return Result(result);
    }

    [HttpPut(Router.StudentRouter.MainId)]
    public async Task<IActionResult> Update(UpdateStudentDto updatestudentDto)
    {
        var result = await mediator.Send(updatestudentDto);
        return Result(result);
    }

    [HttpDelete(Router.StudentRouter.MainId)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteStudentDto() { Id = id });
        return Result(result);
    }
}