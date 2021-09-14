using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanDomain.Entity;
using Microsoft.EntityFrameworkCore;

namespace KanbanDomain.Context
{
    public class KanbanContext: DbContext
    {
        public KanbanContext(DbContextOptions<KanbanContext> options): base(options)
        { }

        public DbSet<Kanban> Kanbans { get; set; }
    }
}
