using System;
using System.Reflection;

namespace Task_12
{
    public class Program
    {
        public static void ObjectPropertyInfo(Type type)
        {
            foreach (var property in type.GetProperties())
            {
                Console.WriteLine($"{property.PropertyType} {property.Name}");
            }
        }

        public static void Main(string[] args)
        {
            var myType = Type.GetType("Task_12.User", false, true);
            ObjectPropertyInfo(myType);
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public void Display()
        {
            Console.WriteLine($"Имя: {Name}  Возраст: {Age}");
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}
