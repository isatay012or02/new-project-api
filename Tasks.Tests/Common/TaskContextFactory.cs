
using System;
using Microsoft.EntityFrameworkCore;
using Tasks.Domain;
using Tasks.Persistence;

namespace Tasks.Tests.Common
{
    public class TaskContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid TaskIdForDelete = Guid.NewGuid();
        public static Guid TaskIdForUpdate = Guid.NewGuid();

        public static TasksDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TasksDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TasksDbContext(options);
            context.Database.EnsureCreated();
            context.STasks.AddRange(
                new TaskD
                {
                    CreationDate = DateTime.Today,
                    DiscriptionTask = "Discription1",
                    EditDate = null,
                    ID = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    NameTask = "Name1",
                    UserID = UserAId
                },
                new TaskD
                {
                    CreationDate = DateTime.Today,
                    DiscriptionTask = "Discription2",
                    EditDate = null,
                    ID = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    NameTask = "Name2",
                    UserID = UserBId
                },
                new TaskD
                {
                    CreationDate = DateTime.Today,
                    DiscriptionTask = "Discription3",
                    EditDate = null,
                    ID = TaskIdForDelete,
                    NameTask = "Name3",
                    UserID = UserAId
                },
                new TaskD
                {
                    CreationDate = DateTime.Today,
                    DiscriptionTask = "Discription4",
                    EditDate = null,
                    ID = TaskIdForUpdate,
                    NameTask = "Name4",
                    UserID = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(TasksDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
