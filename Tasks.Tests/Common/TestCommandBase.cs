using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Persistence;

namespace Tasks.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly TasksDbContext Context;

        public TestCommandBase()
        {
            Context = TaskContextFactory.Create();
        }

        public void Dispose()
        {
            TaskContextFactory.Destroy(Context);
        }
    }
}
