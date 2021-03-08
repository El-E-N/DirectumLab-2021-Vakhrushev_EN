using System;
using Task_2;

namespace Task_4
{
    /// <summary>
    /// Возможность ввода пустого значения для окончания
    /// </summary>
    public class MeetingWithBlankEndTime : Meeting
    {
        public new DateTime? EndTime { get; set; } = null;

        public new TimeSpan? DurationTime
        {
            get
            {
                if (EndTime.HasValue)
                    return ((DateTime)this.EndTime).Subtract(this.StartTime);
                return null;
            }
        }
    }
}