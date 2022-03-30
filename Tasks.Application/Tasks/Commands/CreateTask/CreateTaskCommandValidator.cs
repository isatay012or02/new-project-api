using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Tasks.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createTaskCommand => createTaskCommand.NameTask).NotEmpty().MaximumLength(250);
            RuleFor(createTaskCommand => createTaskCommand.UserID).NotEqual(Guid.Empty);
        }
    }
}
