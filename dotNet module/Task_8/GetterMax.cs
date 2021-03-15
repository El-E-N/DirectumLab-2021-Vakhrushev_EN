using System.Collections.Generic;

namespace Task_8
{
    /// <summary>
    /// Получение максимального значения из 3 элементов неопределенного типа
    /// </summary>
    /// <typeparam name="T">неопределенный тип</typeparam>
    public static class GetterMax<T>
    {
        public static T Max(T element1, T element2, T element3)
        {
            var list = new List<T> { element1, element2, element3 };
            list.Sort();
            return list[2];
        }
    } 
}