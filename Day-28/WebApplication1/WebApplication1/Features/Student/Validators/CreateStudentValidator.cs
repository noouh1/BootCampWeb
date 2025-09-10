using FluentValidation;
using WebApplication1.Features.Student.Command.Models;

namespace WebApplication1.Features.Course.Command.Validators;

public class CreateStudentValidator : AbstractValidator<StudentDto>
{
    public CreateStudentValidator()
    {
        RuleFor(s => s.Sname)
            .NotEmpty()
            .WithMessage("Student name is required");
        RuleFor(c=>c.Age)
            .GreaterThan(0)
            .WithMessage("Student hours must be greater than 0");
    }
}