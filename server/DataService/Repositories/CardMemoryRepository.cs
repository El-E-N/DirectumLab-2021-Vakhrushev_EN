using DataService.Models;
using DataService.Models.Contexts;
using System;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий карт.
    /// </summary>
    public class CardMemoryRepository : MemoryRepository<Card>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public CardMemoryRepository(CardContext context) : base(context)
        {
        }

        /// <summary>
        /// Создание карты.
        /// </summary>
        /// <param name="id">Id карты.</param>
        /// <param name="value">Значение карты.</param>
        /// <param name="name">Название карты.</param>
        public void Create(Guid id, double? value, string name)
        {
            this.Db.Items.Add(new Card(id, value, name));
            this.Db.SaveChanges();
        }
    }
}
