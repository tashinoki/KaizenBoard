using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanDomain.Entity;

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

            var kanban = new Kanban
            {
                Id = new Guid(),
                Title = "テスト",
                IsDeleted = false
            };

            await context.Kanbans.AddAsync(kanban);
            context.SaveChanges();
        }
    }
}
