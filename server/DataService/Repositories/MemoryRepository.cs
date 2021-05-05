using DataService.Models;
using DataService.Models.Contexts;
using Microsoft.EntityFrameworkCore;
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
        protected ItemContext<T> Db { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public MemoryRepository(ItemContext<T> context)
        {
            this.Db = context;
        }

        /// <summary>
        /// Сохранение.
        /// </summary>
        /// <param name="item">Экзмепляр сущности.</param>
        public void Save(T item)
        {
            if (this.Db.Items.Any(o => o.Id == item.Id))
                this.Db.Items.Remove(item);
            this.Db.Items.Add(item);
            this.Db.SaveChanges();
        }

        /// <summary>
        /// Получить по id.
        /// </summary>
        /// <param name="id">Id объекта.</param>
        /// <returns>Объект из БД.</returns>
        public T Get(Guid id) => this.Db.Items.Find(id);

        /// <summary>
        /// Получить все объекты.
        /// </summary>
        /// <returns>Объекты из БД.</returns>
        public IQueryable<T> GetItems() => this.Db.Items;

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="id">Id объекта.</param>
        public void Delete(Guid id)
        {
            T item = this.Db.Items.Find(id);
            if (item != null)
                this.Db.Items.Remove(item);
            this.Db.SaveChanges();
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
                    this.Db.Dispose();

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
