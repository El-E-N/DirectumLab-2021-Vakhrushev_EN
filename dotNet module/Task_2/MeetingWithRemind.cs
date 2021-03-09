using System;
using System.Timers;

namespace Task_2
{
    /// <summary>
    /// класс встречи с напоминанием
    /// </summary>
    public class MeetingWithRemind : Meeting, IRemind
    {
        private Timer timer;

        public MeetingWithRemind(DateTime startTime, DateTime endTime, DateTime eventTime)
        {
            EventTime = eventTime;
            EndTime = endTime;
            StartTime = startTime;
            this.timer = new Timer(60000); // 60 секунд
            this.timer.Elapsed += Remind; // добавление события
            this.timer.AutoReset = true; // повторять много раз
            this.timer.Enabled = true; // включить таймер
        }

        public DateTime EventTime { get; set; }

        private void Remind(object source, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now >= EventTime)
            {
                Console.WriteLine("Событие началось!");
                this.timer.Stop(); // остановка, чтобы больше не работал таймер
            }
        }
    }
}
