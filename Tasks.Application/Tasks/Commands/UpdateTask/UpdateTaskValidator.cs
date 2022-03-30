using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Tasks.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.UserID).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.ID).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.NameTask).NotEmpty().MaximumLength(250);
        }
    }
}
