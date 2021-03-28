using System;
using System.Linq;

namespace DataService.Models
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        public void Create(T item);

        public void Save();

        public T Get(Guid id);

        public IQueryable<T> GetAll();

        public void Delete(Guid id);
    }
}
