using System;
using MediatR;

namespace Tasks.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public Guid UserID { get; set; }
        public Guid ID { get; set; }
    }
}
