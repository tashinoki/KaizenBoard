using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanDomain.Context
{
    public static class DbInitializer
    {
        public static void Initialize(KanbanContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
