using System;
using System.Linq;
using Contract.Entity;

namespace KanbanDomain.Context
{
    public static class DbInitializer
    {
        public async static void Initialize(KanbanContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Kanbans.Any())
            {
                return;   // DB has been seeded
            }

            var kanbanBoard = new KanbanBoard
            {
                Id = new Guid(),
                Title = "サンプル",

            };
            var kanban = new Kanban
            {
                Id = new Guid(),
                Name = "テスト",
                Sequence = 0,
                IsDeleted = false
            };

            await context.Kanbans.AddAsync(kanban);
            context.SaveChanges();
        }
    }
}
