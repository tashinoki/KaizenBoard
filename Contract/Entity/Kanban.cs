using System;
using System.Collections.Generic;

namespace Contract.Entity
{
    public class Kanban
    {
        public Guid Id { get; set; }

        public Guid BoardId { get; set; }
        
        public string Name { get; set; }

        public int Sequence { get; set; }

        public bool IsDeleted { get; set; }

        public IReadOnlyList<MyTask> Tasks { get; set; }
    }
}
