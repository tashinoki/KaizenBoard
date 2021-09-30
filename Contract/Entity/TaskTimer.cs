using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Entity
{
    public class TaskTimer
    {
        public DateTimeOffset StartedAt { get; private set; }

        public DateTimeOffset FinishedAt { get; private set; }

        public bool IsFinised { get; private set; } = false;


        public void Start()
        {
            StartedAt = DateTimeOffset.UtcNow;
        }

        public void Stop()
        {
            FinishedAt = DateTimeOffset.UtcNow;
            IsFinised = true;
        }
    }
}
