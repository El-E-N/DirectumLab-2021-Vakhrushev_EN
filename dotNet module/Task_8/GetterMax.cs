using System;

namespace Task_8
{
    /// <summary>
    /// Получение максимального значения из 3 элементов неопределенного типа
    /// </summary>
    /// <typeparam name="T">неопределенный тип</typeparam>
    public static class GetterMax<T> where T : IComparable
    {
        public static T Max(T element1, T element2, T element3)
        {
            if (element1.CompareTo(element2) >= 0 && element1.CompareTo(element3) >= 0)
                return element1;
            else if (element2.CompareTo(element1) >= 0 && element2.CompareTo(element3) >= 0)
                return element2;
            else
                return element3;
        }
    } 
}