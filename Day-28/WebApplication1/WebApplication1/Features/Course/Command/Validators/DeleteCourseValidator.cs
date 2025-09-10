using FluentValidation;
using WebApplication1.Features.Student.Command.Models;

namespace WebApplication1.Features.Course.Command.Validators;

public class DeleteCourseValidator : AbstractValidator<DeleteCourseDto>
{
    public DeleteCourseValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Course Id is required");
    }
}