using AutoMapper;
using System;
using Tasks.Application.Interfaces;
using Tasks.Application.Common.Mappings;
using Tasks.Persistence;
using Xunit;

namespace Tasks.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public TasksDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = TaskContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(ITasksDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            TaskContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
