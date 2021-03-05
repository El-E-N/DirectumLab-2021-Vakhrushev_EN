using System;

namespace Task_2
{
    /// <summary>
    /// Класс встречи
    /// </summary>
    public class Meeting
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        /// <summary>
        /// будет высчитываться автоматически при запросе продолжительности 
        /// </summary>
        public TimeSpan DurationTime { get => this.EndTime.Subtract(this.StartTime); }
    }
}
