using FluentValidation;
using WebApplication1.Features.Student.Command.Models;

namespace WebApplication1.Features.Course.Command.Validators;

public class UpdateCourseValidator : AbstractValidator<UpdateCourseDto>
{
    public UpdateCourseValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Course Id is required");
    }
}