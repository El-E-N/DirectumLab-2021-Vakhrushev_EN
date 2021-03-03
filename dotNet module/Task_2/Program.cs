using System;

namespace Task_2
{
    /*public class Meeting1
    {
        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan durationTime;
        Meeting1()
        {
            startTime = new DateTime();
            endTime = new DateTime();
            durationTime = endTime.Subtract(startTime);
        }
        Meeting1(DateTime st, DateTime et)
        {
            //Console.WriteLine("Время конца меньше времени начала");
            SetNewTime(st, et);
        }
        public void SetNewTime(DateTime st, DateTime et)
        {
            if (st < et)
            {
                startTime = st;
                endTime = et;
            }
            else
            {
                startTime = et;
                endTime = st;
                //Console.WriteLine("Время конца меньше времени начала");
            }
            durationTime = endTime.Subtract(startTime);
        }
        public void SetStartTime(DateTime st)
        {
            //Console.WriteLine("Время конца меньше времени начала");
            SetNewTime(st, endTime);
        }
        public void SetEndTime(DateTime et)
        {
            //Console.WriteLine("Время конца меньше времени начала");
            SetNewTime(startTime, et);
        }
        public DateTime GetStartTime()
        {
            return startTime;
        }
        public DateTime GetEndTime()
        {
            return endTime;
        }
        public TimeSpan GetDurationTime()
        {
            return durationTime;
        }
    }*/

    /// <summary>
    /// Класс встречи
    /// </summary>
    public abstract class Meeting
    {
        private DateTime startTime; 
        private DateTime endTime;
        private TimeSpan durationTime; // продолжительность

        public DateTime StartTime
        {
            get { return this.startTime; }
            set { this.startTime = value; }
        }

        public DateTime EndTime
        {
            get { return this.endTime; }
            set { this.endTime = value; }
        }

        /// <summary>
        /// будет высчитываться автоматически при запросе продолжительности 
        /// </summary>
        public TimeSpan DurationTime
        {
            get 
            { 
                this.durationTime = this.endTime.Subtract(this.startTime);
                return this.durationTime;
            }
        }
    }

    /// <summary>
    /// интерфейс напоминания
    /// </summary>
    public interface IRemind
    {
        public DateTime EventTime { get; set; }
    }

    /// <summary>
    /// класс встречи с напоминанием
    /// </summary>
    public class MeetingWithRemind : Meeting, IRemind
    {
        private System.Timers.Timer timer;

        public MeetingWithRemind(DateTime start_time, DateTime end_time, DateTime event_time)
        {
            EventTime = event_time;
            EndTime = end_time;
            StartTime = start_time;
            this.timer = new System.Timers.Timer(60000); // 60 секунд
            this.timer.Elapsed += Remind; // добавление события
            this.timer.AutoReset = true; // повторять много раз
            this.timer.Enabled = true; // включить таймер
        }

        private DateTime eventTime;

        public DateTime EventTime
        {
            get { return this.eventTime; }
            set { this.eventTime = value; }
        }

        private void Remind(object source, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now > EventTime)
            {
                Console.WriteLine("Событие началось!");
                this.timer.Stop(); // остановка, чтобы больше не работал таймер
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime start1 = new DateTime();
            DateTime end1 = new DateTime(2021, 3, 2, 22, 49, 30);
            DateTime event1 = new DateTime(2021, 3, 3, 18, 43, 00);
            MeetingWithRemind mwr = new MeetingWithRemind(start1, end1, event1);
            // while (DateTime.Now < new DateTime(2021, 3, 4, 0, 0, 0)) { }
            Console.ReadKey(); // нужно подождать для примера, пока событие не сработает, 
                               // и нажать любую клавишу для выхода из программы
        }
    }
}
