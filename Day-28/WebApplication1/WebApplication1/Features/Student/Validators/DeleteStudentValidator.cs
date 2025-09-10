using FluentValidation;
using WebApplication1.Features.Student.Command.Models;

namespace WebApplication1.Features.Course.Command.Validators;

public class DeleteStudentValidator : AbstractValidator<DeleteStudentDto>
{
    public DeleteStudentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Student Id is required");
    }
}