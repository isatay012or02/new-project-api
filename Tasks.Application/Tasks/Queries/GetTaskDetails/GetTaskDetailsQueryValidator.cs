using FluentValidation;
using System;

namespace Tasks.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryValidator : AbstractValidator<GetTaskDetailsQuery>
    {
        public GetTaskDetailsQueryValidator()
        {
            RuleFor(task => task.ID).NotEqual(Guid.Empty);
            RuleFor(task => task.UserID).NotEqual(Guid.Empty);
        }
    }
}
