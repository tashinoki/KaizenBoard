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
            var sum = timers
                    .Where(t => t.IsFinised)
                    .Select(t => t.Elapsed());
        }
    }
}
