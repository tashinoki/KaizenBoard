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

        public DbSet<Member> Members { get; set; }

        public DbSet<KanbanBoard> KanbanBoards { get; set; }

        public DbSet<TaskTimer> TaskTimers { get; set; }

        public DbSet<MyTask> MyTasks { get; set; }

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

            modelBuilder.Entity<Kanban>()
                .HasIndex(k => k.Sequence)
                .IsUnique();

            modelBuilder.Entity<Member>()
                .Property(m => m.Id)
                .IsRequired();
        }
    }
}
