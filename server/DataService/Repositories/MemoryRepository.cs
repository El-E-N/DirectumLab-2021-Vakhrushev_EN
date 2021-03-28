using DataService.Models;
using System;
using System.Linq;

namespace DataService.Repositories
{
    public class MemoryRepository<T> : IRepository<T>
        where T : class
    {
        private ItemContext<T> db;

        public MemoryRepository(ItemContext<T> context)
        {
            this.db = context;
        }

        public void Create(T item)
        {
            this.db.Items.Add(item);
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

        public T Get(Guid id) => this.db.Items.Find(id);

        public IQueryable<T> GetAll() => this.db.Items;

        public void Delete(Guid id)
        {
            T item = this.db.Items.Find(id);
            if (item != null)
                this.db.Items.Remove(item);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
