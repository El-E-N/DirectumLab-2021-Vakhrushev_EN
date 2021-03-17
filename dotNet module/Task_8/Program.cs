using System;
using System.Collections.Generic;
using System.IO;

namespace Task_8
{
    public class Program
    {
        public static void Task2()
        {
            Console.WriteLine("Максимальное из a, ab и abc: " + GetterMax<string>.Max("abc", "ab", "a"));
        }

        public static void Task3()
        {
            // List для возможности получения доступа к элементам
            var listInt = new List<int> { 1, 2, 3, 4, 5 };
            var listStr = new List<string> { "a", "b", "c", "d", "e" };

            // Dictionary<TKey, TValue> - для хранения пар ключ-значение с уникальными ключами
            var dictInt = new Dictionary<int, string>();
            dictInt.Add(1, "a");
            dictInt.Add(2, "b");
            dictInt.Add(3, "c");

            var dictStr = new Dictionary<string, int>();
            dictStr.Add("a", 1);
            dictStr.Add("b", 2);
            dictStr.Add("c", 3);

            Console.WriteLine("Int List:");
            foreach (var element in listInt)
                Console.WriteLine(element);

            Console.WriteLine("String List:");
            foreach (var element in listStr)
                Console.WriteLine(element);

            Console.WriteLine("Dictionary<int, string>:");
            foreach (var element in dictInt)
                Console.WriteLine(element.Key + ": " + element.Value);

            Console.WriteLine("Dictionary<string, int>:");
            foreach (var element in dictStr)
                Console.WriteLine(element.Key + ": " + element.Value);
            // HashSet<T> - набор уникальных элементов без сортировки
            // SortedSet<T> набор уникальных элементов с сортировкой
            // SortedDictionary<TKey, TValue> - сортированный словарь
            // SortedList<TKey, TValue> - аналогично
            // Queue<T> реализует принцип FIFO (first in, first out) - первым пришел, первым вышел
            // Stack<T> похож на класс Queue<T>, но он реализует принцип LIFO (последний пришел, первый вышел)
            // Также множество классов с такими же названиями с приставкой Concurrent для потокобезопасности
        }

        public static void Task4(string path)
        {
            var fileReader = new FileReader(path);
            Console.WriteLine(path + ":");
            foreach (var line in fileReader)
                Console.WriteLine(line);
            fileReader.Dispose();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Задача 2");
            Task2();

            Console.WriteLine("\nЗадача 3");
            Task3();

            Console.WriteLine("\nЗадание 4");
            var path = "MyTextFile.txt";
            Task4(path);
        }
    }
}