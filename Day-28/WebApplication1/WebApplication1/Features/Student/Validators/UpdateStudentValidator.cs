using FluentValidation;
using WebApplication1.Features.Student.Command.Models;

namespace WebApplication1.Features.Course.Command.Validators;

public class UpdateStudentValidator : AbstractValidator<UpdateStudentDto>
{
    public UpdateStudentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Student Id is required");
    }
}