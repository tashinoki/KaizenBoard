using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Entity
{
    public class Member
    {
        public Guid Id { get; set; }

        public string HandleName { get; set; }

        public string MemberId { get; set; }

        public bool IsDeleted { get; set; }

        public IReadOnlyList<KanbanBoard> KanbanBoards { get; set; }

        public IReadOnlyList<MyTask> MyTasks { get; set; }
    }
}
