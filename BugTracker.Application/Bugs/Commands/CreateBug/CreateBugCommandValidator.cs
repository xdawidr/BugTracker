using BugTracker.Application.Projects.Commands.CreateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Bugs.Commands.CreateBug
{
    public class CreateBugCommandValidator : AbstractValidator<CreateBugCommand>
    {
        public CreateBugCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Environment).NotEmpty();
        }
    }
}
