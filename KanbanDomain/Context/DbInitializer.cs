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

            var kanban = new Kanban
            {
                Id = new Guid(),
                Name = "テスト",
                Sequence = 0,
                IsDeleted = false
            };

            var kanban2 = new Kanban
            {
                Id = new Guid(),
                Name = "KaizenBoard",
                Sequence = 1,
                IsDeleted = false,
            };

            var kanbanBoard = new KanbanBoard
            {
                Id = new Guid(),
                Title = "サンプル",
                Priority = 0,
                Kanbans = new List<Kanban> { kanban, kanban2 }

            };
            var kanbanBoard2 = new KanbanBoard
            {
                Id = new Guid(),
                Title = "KaizenBoard",
                Priority = 1
            };

            await context.KanbanBoards.AddAsync(kanbanBoard);
            await context.KanbanBoards.AddAsync(kanbanBoard2);
            await context.Kanbans.AddAsync(kanban);
            await context.Kanbans.AddAsync(kanban2);

            var member = new Member
            {
                Id = new Guid(),
                HandleName = "kino",
                MemberId = "kino",
                KanbanBoards = new List<KanbanBoard> { kanbanBoard, kanbanBoard2 },
                IsDeleted = false
            };

            await context.AddAsync(member);

            context.SaveChanges();
        }
    }
}
