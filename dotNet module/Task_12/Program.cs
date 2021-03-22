using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task_12
{
    /// <summary>
    /// Класс выполнения программы.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод для 1 задания.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <returns>Названия и значения свойств объекта.</returns>
        public static List<Dictionary<string, string>> ObjectPropertyInfo(object obj)
        {
            var listResult = new List<Dictionary<string, string>>();
            var type = obj.GetType();
            foreach (var property in type.GetProperties(BindingFlags.DeclaredOnly
                            | BindingFlags.Instance | BindingFlags.NonPublic
                            | BindingFlags.Static | BindingFlags.Public))
                listResult.Add(new Dictionary<string, string> 
                { 
                    { "Name", property.Name }, 
                    { "Value", property.GetValue(obj).ToString() } 
                });
            return listResult;
        }

        /// <summary>
        /// Метод для 2 задания. Выводит в консоль названия и значения свойств объекта класса по умолчанию.
        /// </summary>
        /// <param name="pathOfAssembly">Путь к решению (.dll).</param>
        /// <param name="pathOfClass">Путь к классу.</param>
        public static void ShowPropertyInfo(string pathOfAssembly, string pathOfClass)
        {
            var assembly = Assembly.LoadFrom(pathOfAssembly);
            var type = assembly.GetType(pathOfClass, true, true);
            var obj = Activator.CreateInstance(type);
            foreach (var property in type.GetProperties(BindingFlags.DeclaredOnly
                            | BindingFlags.Instance | BindingFlags.NonPublic
                            | BindingFlags.Static | BindingFlags.Public))
                Console.WriteLine($"Имя свойства: {property.Name}; значение: {property.GetValue(obj)}");
        }

        /// <summary>
        /// Метод для 3 задания.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <returns>Названия и значения свойств объекта.</returns>
        public static List<Dictionary<string, string>> ObjectPropertyInfoWithoutObsolete(object obj)
        {
            var listResult = new List<Dictionary<string, string>>();
            var type = obj.GetType();
            foreach (var property in type.GetProperties(BindingFlags.DeclaredOnly
                            | BindingFlags.Instance | BindingFlags.NonPublic
                            | BindingFlags.Static | BindingFlags.Public))
            {
                bool propertyHasObsolete() 
                {
                    foreach (ObsoleteAttribute a in property.GetCustomAttributes())
                        return true;
                    return false;
                }

                if (!propertyHasObsolete())
                    listResult.Add(new Dictionary<string, string>
                    {
                        { "Name", property.Name },
                        { "Value", property.GetValue(obj).ToString() }
                    });
            }

            return listResult;
        }

        /// <summary>
        /// Основной метод программы.
        /// </summary>
        /// <param name="args">Для консоли.</param>
        [Obsolete]
        public static void Main(string[] args)
        {
            Console.WriteLine("Задание 1:");
            foreach (var dict in ObjectPropertyInfo(new User("MyName", 22, 12345)))
                Console.WriteLine($"Имя свойства: {dict["Name"]}; значение: {dict["Value"]}");
            
            Console.WriteLine("\nЗадание 2:");
            var pathOfAssembly = "Task_12.dll";
            var pathOfClass = "Task_12.User";
            ShowPropertyInfo(pathOfAssembly, pathOfClass);

            Console.WriteLine("\nЗадание 3:");
            foreach (var dict in ObjectPropertyInfoWithoutObsolete(new User("MyName", 22, 12345)))
                Console.WriteLine($"Имя свойства: {dict["Name"]}; значение: {dict["Value"]}");

            Console.WriteLine("\nЗадание 5:");
            ShowPropertyInfo("User1.dll", "User1.User1");
            ShowPropertyInfo("User2.dll", "User2.User2");
        }
    }
}
