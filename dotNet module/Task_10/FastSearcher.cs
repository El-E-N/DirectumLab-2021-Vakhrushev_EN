using System.Collections.Generic;
using System.Linq;
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

        public FastSearcher(uint max, uint min)
        {
            this.MaxCountOfParallelTasks = max;
            this.MinCountOfValueInCollection = min;
            this.CountOfParallelTasks = 1;
        }

        /// <summary>
        /// Список из нужных значений
        /// </summary>
        public List<T> Values { get; } = new List<T>();

        public async Task SearchValue(IEnumerable<T> collection, Condition cond)
        { 
            if (collection.Count() / 2 >= this.MinCountOfValueInCollection
                && this.CountOfParallelTasks + 1 <= this.MaxCountOfParallelTasks)
            {
                this.CountOfParallelTasks++; // при разбиении количество пооков увеличивается на 1
                var col1 = collection.Take(collection.Count() / 2);
                var col2 = collection.Skip(collection.Count() / 2);
                var task1 = this.SearchValue(col1, cond);
                var task2 = this.SearchValue(col2, cond);
                await Task.WhenAll(task1, task2);
            }
            else
            {
                foreach (var element in collection)
                    if (cond(element))
                        this.Values.Add(element);
                this.CountOfParallelTasks--; // при завершении задача прерывается и появляется возможность заменить на новую задачу
            }
        }
    }
}
