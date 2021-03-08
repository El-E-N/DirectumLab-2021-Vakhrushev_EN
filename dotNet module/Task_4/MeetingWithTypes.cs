using System;
using Task_2;

namespace Task_4
{
    /// <summary>
    /// Добавлен тип
    /// </summary>
    public class MeetingWithTypes : Meeting
    {
        private string type = string.Empty;
        private static string[] possibleEvents = { "совещание", "поручение", "звонок", "день рождения" };

        public string Type 
        {
            get => this.type;
            set
            {
                if (Array.IndexOf(possibleEvents, value) > -1)
                    this.type = value;
                else
                    Console.WriteLine("Недопустимое значение для события!");
            }
        }
    }
}