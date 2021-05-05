using System;

namespace Task_13_Framework
{
    /// <summary>
    /// Основной класс.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод запуска программы.
        /// </summary>
        /// <param name="args">Информация от консоли.</param>
        public static void Main(string[] args)
        {
            CreatorMultiplicationTable.WithEarlyBinding("WithEarlyBinding.xlsx", 5);
            Console.WriteLine("Раннее связывание окончено");
            CreatorMultiplicationTable.WithLateBinding("WithLateBinding.xlsx", 5);
            Console.WriteLine("Позднее связывание окончено");
            Console.ReadLine();
        }
    }
}
