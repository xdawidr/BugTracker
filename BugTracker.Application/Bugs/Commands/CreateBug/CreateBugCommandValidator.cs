using FluentValidation;

namespace BugTracker.Application.Bugs.Commands.CreateBug
{
    public class CreateBugCommandValidator : AbstractValidator<CreateBugCommand>
    {
        public CreateBugCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Environment).NotEmpty();
        }
    }
}
