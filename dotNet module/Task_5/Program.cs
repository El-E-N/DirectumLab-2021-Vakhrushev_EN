using System;
using System.Collections;

namespace Task_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine("AAA.Equals(AAA): " + new StringValue("AAA").Equals(new StringValue("AAA")));

            Console.WriteLine("\nЗадание 2");
            Console.WriteLine("AAA == AAA: " + (new StringValue("AAA") == new StringValue("AAA")));
            Console.WriteLine("AAB != AAA: " + (new StringValue("AAB") != new StringValue("AAA")));

            Console.WriteLine("\nЗадание 3");
            var twoComplexes = new ArrayList() 
            { 
                new Complex() { Re = 3, Im = 5 }, new Complex() { Re = 2, Im = 2 }
            };
            twoComplexes.Sort();
            foreach (Complex complex in twoComplexes)
                Console.WriteLine($"Re: {complex.Re}; Im: {complex.Im}. ");
        }
    }
}
