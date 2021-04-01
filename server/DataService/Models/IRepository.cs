using System;
using System.Linq;

namespace DataService.Models
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    /// <typeparam name="T">Любой класс, который он будет содержать.</typeparam>
    public interface IRepository<T> : IDisposable
        where T : class
    {
        /// <summary>
        /// Создание.
        /// </summary>
        /// <param name="item">Объект.</param>
        public void Create(T item);

        /// <summary>
        /// Сохранение.
        /// </summary>
        public void Save();

        /// <summary>
        /// Получение из БД по id.
        /// </summary>
        /// <param name="id">Id объекта.</param>
        /// <returns>Объект.</returns>
        public T Get(Guid id);

        /// <summary>
        /// Получить все объекты.
        /// </summary>
        /// <returns>Все объекты.</returns>
        public IQueryable<T> GetAll();

        public void Delete(Guid id);
    }
}
