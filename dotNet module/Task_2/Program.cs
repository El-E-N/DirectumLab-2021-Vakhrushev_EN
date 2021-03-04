using System;

namespace Task_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime(2021, 3, 2, 22, 49, 30);
            DateTime remindTime = new DateTime(2021, 3, 4, 20, 07, 00);
            MeetingWithRemind meeting = new MeetingWithRemind(startTime, endTime, remindTime);
            Console.ReadKey(); // нужно подождать для примера, пока событие не сработает, 
                               // и нажать любую клавишу для выхода из программы
        }
    }
}
