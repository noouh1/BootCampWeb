using FluentValidation;
using WebApplication1.Features.Student.Command.Models;

namespace WebApplication1.Features.Course.Command.Validators;

public class CreateCourseValidator : AbstractValidator<CourseDto>
{
    public CreateCourseValidator()
    {
        RuleFor(c => c.Cname)
            .NotEmpty()
            .WithMessage("Course name is required");
        RuleFor(c=>c.Hours)
            .GreaterThan(0)
            .WithMessage("Course hours must be greater than 0");
    }
}