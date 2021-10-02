using System;

namespace Contract.Entity
{
    public class TaskTimer
    {
        public Guid Id { get; set; }
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

        public TimeSpan Elapsed()
        {
            // 開始時刻と終了時刻の大商比較はしたいけど
            // このメソッドでやるべきか？
            return FinishedAt.Subtract(StartedAt);
        }
    }
}
