using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Task_10
{
    /// <summary>
    /// Быстрый поиск значений в коллекции
    /// </summary>
    /// <typeparam name="T">тип данных для коллекции</typeparam>
    public class FastSearcher<T>
    {
        /// <summary>
        /// Максимальное количество параллельных задач
        /// </summary>
        public uint MaxCountOfParallelTasks { get; set; } = 10;

        /// <summary>
        /// Минимальное количество значений в коллекции
        /// </summary>
        public uint MinCountOfValueInCollection { get; set; } = 2;

        /// <summary>
        /// Количество параллельных задач в настоящее время
        /// </summary>
        private uint CountOfParallelTasks { get; set; } = 1;

        /// <summary>
        /// Список из нужных значений
        /// </summary>
        public List<T> Values { get; } = new List<T>();

        public async Task SearchValue(Collection<T> collection, Condition cond)
        { 
            if (collection.Count / 2 >= this.MinCountOfValueInCollection
                && this.CountOfParallelTasks + 1 <= this.MaxCountOfParallelTasks)
            {
                this.CountOfParallelTasks++; // при разбиении количество пооков увеличивается на 1
                var col1 = new Collection<T> { };
                var col2 = new Collection<T> { };
                int i = 0;
                for (; i < collection.Count / 2; i++)
                    col1.Add(collection[i]);
                for (; i < collection.Count; i++)
                    col2.Add(collection[i]);
                await this.SearchValue(col2, cond);
                await this.SearchValue(col1, cond);
            }
            else
            {
                foreach (var element in collection)
                    if (cond(element))
                        this.Values.Add(element);
                this.CountOfParallelTasks--;
            }
        }
    }
}
