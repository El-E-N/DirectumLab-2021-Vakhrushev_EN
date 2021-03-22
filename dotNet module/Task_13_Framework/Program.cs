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
            CreatorMultiplicationTable.WithEarlyBinding("EarlyBinding.xlsx");
            Console.WriteLine("Раннее связывание окончено");
            CreatorMultiplicationTable.WithEarlyBinding("LateBinding.xlsx");
            Console.WriteLine("Позднее связывание окончено");
            Console.ReadLine();
        }
    }
}
