using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contract.Entity;

namespace KanbanDomain.Context
{
    public class KanbanContext: DbContext
    {
        public KanbanContext(DbContextOptions<KanbanContext> options): base(options)
        {
        }

        public DbSet<Kanban> Kanbans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add constraints on columns
            modelBuilder.Entity<Kanban>()
                .Property(k => k.Id)
                .IsRequired();
        }
    }
}
