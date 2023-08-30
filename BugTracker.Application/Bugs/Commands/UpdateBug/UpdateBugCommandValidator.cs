using BugTracker.Application.Bugs.Commands.CreateBug;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommandValidator : AbstractValidator<UpdateBugCommand>
    {
        public UpdateBugCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Environment).NotEmpty();
        }
    }
}
