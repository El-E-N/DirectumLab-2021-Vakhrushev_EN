using System;
using System.IO;

namespace Task_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            { 
                var count = CountLines("ClientConnectionLog.log", new DateTime(2007, 12, 5, 13, 50, 0), new DateTime(2007, 12, 11, 17, 01, 15));
                Console.WriteLine("Количество записей в интервале = " + count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nДополнительное задание");
            Console.WriteLine(new MyClass("Егор", 1000000)); // вывод пути к классу
            Console.WriteLine(new MyClassWithToString("Егор", 1000000)); // переопределенный метод
            // то есть нужно переопределять метод ToString, если хотим выводить нужную нам информацию об объекте класса
        }

        /// <summary>
        /// Подсчет количества записей в определенном интервале
        /// </summary>
        /// <param name="pathToFile">путь к файлу</param>
        /// <param name="start">начало интервала</param>
        /// <param name="end">конец интервала</param>
        /// <returns>количество записей</returns>
        public static int CountLines(string pathToFile, DateTime start, DateTime end)
        {
            int count = 0;
            using (var reader = new StreamReader(pathToFile))
            {
                reader.ReadLine(); // чтобы не рассматривать шапку файла
                while (!reader.EndOfStream)
                {
                    var arrayOfLine = reader.ReadLine().Split("\t");
                    var tempTime = DateTime.Parse(arrayOfLine[0] + " " + arrayOfLine[1]);
                    if (start <= tempTime && tempTime <= end)
                        count++;
                }
            }
            return count;
        }
    }
}
