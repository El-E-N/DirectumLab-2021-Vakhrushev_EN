using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public uint MaxCountOfParallelTasks { get; }

        /// <summary>
        /// Минимальное количество значений в коллекции
        /// </summary>
        public uint MinCountOfValueInCollection { get; }

        /// <summary>
        /// Количество параллельных задач в настоящее время
        /// </summary>
        private uint CountOfParallelTasks { get; set; }

        public FastSearcher(uint maxCountOfParallelTasks, uint minCountOfValueInCollection)
        {
            this.MaxCountOfParallelTasks = maxCountOfParallelTasks;
            this.MinCountOfValueInCollection = minCountOfValueInCollection;
            this.CountOfParallelTasks = 1;
        }

        /// <summary>
        /// Список из нужных значений
        /// </summary>
        private readonly List<T> values = new List<T>();

        public IEnumerable<T> GetValues()
        {
            return this.values;
        }

        public async Task SearchValue(IEnumerable<T> collection, Condition cond)
        {
            var centerList = collection.Count() / 2;
            if (centerList >= this.MinCountOfValueInCollection
                && this.CountOfParallelTasks + 1 <= this.MaxCountOfParallelTasks)
            {
                var count = (int)this.CountOfParallelTasks;
                Interlocked.Increment(ref count); // при разбиении количество пооков увеличивается на 1
                var col1 = collection.Take(centerList);
                var col2 = collection.Skip(centerList);
                var task1 = this.SearchValue(col1, cond);
                var task2 = this.SearchValue(col2, cond);
                await Task.WhenAll(task1, task2);
            }
            else
            {
                foreach (var element in collection)
                    if (cond(element))
                        this.values.Add(element);
                var count = (int)this.CountOfParallelTasks;
                Interlocked.Decrement(ref count); // при завершении задача прерывается и появляется
                                                  // возможность заменить на новую задачу
            }
        }
    }
}
