using DataService.Models;
using System;
using System.Linq;

namespace DataService.Repositories
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    /// <typeparam name="T">Любой класс, который он будет содержать.</typeparam>
    public interface IRepository<T> where T : class, IEntity
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

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(Guid id);
    }
}
