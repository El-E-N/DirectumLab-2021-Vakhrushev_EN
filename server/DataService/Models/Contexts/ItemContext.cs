using Microsoft.EntityFrameworkCore;

namespace DataService.Models.Contexts
{
    /// <summary>
    /// Контекст объекта.
    /// </summary>
    /// <typeparam name="T">Любой класс объекта.</typeparam>
    public class ItemContext<T> : DbContext
        where T : class
    {
        /// <summary>
        /// Конструктор объекта.
        /// </summary>
        /// <param name="options">Опции.</param>
        public ItemContext(DbContextOptions options) : base(options)
        { }

        /// <summary>
        /// Объекты из БД.
        /// </summary>
        public virtual DbSet<T> Items { get; set; }
    }
}
