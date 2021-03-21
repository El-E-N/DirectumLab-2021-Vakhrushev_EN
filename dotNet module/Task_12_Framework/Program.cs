using System;

namespace Task_12
{
    /// <summary>
    /// Класс выполнения программы.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Основной метод программы.
        /// </summary>
        /// <param name="args">Для консоли.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Задание 4:");
            foreach (var pair in ConfigReader.GetPairs())
                Console.WriteLine("Key: " + pair["Key"] + ", Value: " + pair["Value"]);
            Console.ReadLine();
        }
    }
}
