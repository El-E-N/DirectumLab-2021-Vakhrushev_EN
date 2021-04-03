using DataService.Models;
using DataService.Models.Contexts;
using System;
using System.Linq;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий объектов.
    /// </summary>
    /// <typeparam name="T">Любой класс объекта.</typeparam>
    public class MemoryRepository<T> : IRepository<T>, IDisposable
        where T : class, IEntity
    {
        /// <summary>
        /// Контекст объекта.
        /// </summary>
        private ItemContext<T> db;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public MemoryRepository(ItemContext<T> context)
        {
            this.db = context;
        }

        /// <summary>
        /// Создание.
        /// </summary>
        /// <param name="item">Объект.</param>
        public void Create(T item)
        {
            this.db.Items.Add(item);
        }

        /// <summary>
        /// Сохранение.
        /// </summary>
        public void Save()
        {
            this.db.SaveChanges();
        }

        /// <summary>
        /// Получить по id.
        /// </summary>
        /// <param name="id">Id объекта.</param>
        /// <returns>Объект из БД.</returns>
        public T Get(Guid id) => this.db.Items.Find(id);

        /// <summary>
        /// Получить все объекты.
        /// </summary>
        /// <returns>Объекты из БД.</returns>
        public IQueryable<T> GetAll() => this.db.Items;

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="id">Id объекта.</param>
        public void Delete(Guid id)
        {
            T item = this.db.Items.Find(id);
            if (item != null)
                this.db.Items.Remove(item);
        }

        /// <summary>
        /// Для закрытия.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Закрытие потока.
        /// </summary>
        /// <param name="disposing">Нужно ли закрывать.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    this.db.Dispose();

            this.disposed = true;
        }

        /// <summary>
        /// Закрытие потока.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
