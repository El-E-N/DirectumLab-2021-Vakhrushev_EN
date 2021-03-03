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
    public abstract class Meeting
    {
        private DateTime start_time;
        private DateTime end_time;
        private TimeSpan duration_time;
        public DateTime StartTime
        {
            get { return start_time; }
            set { start_time = value; }
        }
        public DateTime EndTime
        {
            get { return end_time; }
            set { end_time = value; }
        }
        public TimeSpan DurationTime
        {
            get 
            { 
                duration_time = end_time.Subtract(start_time);
                return duration_time;
            }
        }
    }
    interface IRemind
    {
        public DateTime EventTime { get; set; }
    }
    public class MeetingWithRemind : Meeting, IRemind
    {
        private static System.Timers.Timer timer;
        public MeetingWithRemind(DateTime start_time, DateTime end_time, DateTime event_time)
        {
            EventTime = event_time;
            EndTime = end_time;
            StartTime = start_time;
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += Remind;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private DateTime event_time;
        public DateTime EventTime
        {
            get { return event_time; }
            set { event_time = value; }
        }
        private void Remind(object source, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now > EventTime)
            {
                Console.WriteLine("Событие началось!");
                timer.Stop();
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime start1 = new DateTime();
            DateTime end1 = new DateTime(2021, 3, 2, 22, 49, 30);
            DateTime event1 = new DateTime(2021, 3, 2, 23, 15, 00);
            MeetingWithRemind mwr = new MeetingWithRemind(start1, end1, event1);
            while (DateTime.Now < new DateTime(2021, 3, 3, 0, 0, 0)) { }
            //Console.ReadKey();
        }
    }
}
