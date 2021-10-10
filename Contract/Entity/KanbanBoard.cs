using System;
using System.Collections.Generic;

namespace Contract.Entity
{
    public class KanbanBoard
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int Priority { get; set; }

        public IList<Kanban> Kanbans { get; set; }

        public IList<Member> Members { get; set; }
    }
}
