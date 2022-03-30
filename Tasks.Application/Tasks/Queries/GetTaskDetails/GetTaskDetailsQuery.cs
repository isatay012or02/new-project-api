using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Tasks.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<GetTaskVm>
    {
        public Guid UserID { get; set; }
        public Guid ID { get; set; }
    }
}
