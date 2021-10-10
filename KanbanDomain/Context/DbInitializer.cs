using System;
using System.Linq;
using System.Collections.Generic;
using Contract.Entity;

namespace KanbanDomain.Context
{
    public static class DbInitializer
    {
        public async static void Initialize(KanbanContext context)
        {
            
            
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.KanbanBoards.Any())
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
                Priority = 0,
                IsDeleted = false
            };

            var kanban2 = new Kanban
            {
                Id = new Guid(),
                Name = "KaizenBoard",
                Priority = 1,
                IsDeleted = false,
            };

            await context.KanbanBoards.AddAsync(kanbanBoard);
            await context.Kanbans.AddAsync(kanban);
            await context.Kanbans.AddAsync(kanban2);

            var member = new Member
            {
                Id = new Guid(),
                HandleName = "kino",
                MemberId = "kino",
                KanbanBoards = new List<KanbanBoard> { kanbanBoard },
                IsDeleted = false
            };

            await context.AddAsync(member);

            context.SaveChanges();
        }
    }
}
