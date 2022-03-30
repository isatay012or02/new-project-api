using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tasks.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public Guid UserID { get; set; }
        public Guid ID { get; set; }
        public string NameTask { get; set; }
        public string DiscriptionTask { get; set; }
    }
}
