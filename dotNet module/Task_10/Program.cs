using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Task_10
{
    public delegate bool Condition(object element);

    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new Collection<int> { };
            for (int i = 0; i < 1000; i++)
                list.Add(i);
            Condition cond = IsEven;
            var fastSearcher = new FastSearcher<int>(30, 5);
            var t = fastSearcher.SearchValue(list, cond);
            foreach (var value in fastSearcher.Values)
                Console.WriteLine(value);
        }

        /// <summary>
        /// Является ли четным числом
        /// </summary>
        /// <param name="number">число</param>
        /// <returns>true, если четное</returns>
        public static bool IsEven(object number)
        {
            if ((int)number % 2 == 0)
                return true;
            return false;
        }
    }
}
