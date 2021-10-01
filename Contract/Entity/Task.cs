using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Entity
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<TaskTimer> Timers { get;  set; }

        public IList<Member> Members { get; set; }

        public void TotalTime()
        {
            var sum = Timers
                    .Where(t => t.IsFinised)
                    .Select(t => t.Elapsed());
        }

        public Guid KanbanId { get; set; }

        public Kanban Kanban { get; set; }
    }
}
