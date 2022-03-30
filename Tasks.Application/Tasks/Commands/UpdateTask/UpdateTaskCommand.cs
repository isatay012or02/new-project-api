using System;
using MediatR;

namespace Tasks.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public Guid UserID { get; set; }
        public Guid ID { get; set; }
        public string NameTask { get; set; }
        public string DiscriptionTask { get; set; }
    }
}
