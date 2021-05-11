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
            this.Db.Items.Add(new Card(new Guid(), 0, "number"));
            this.Db.Items.Add(new Card(new Guid(), 0.5, "number"));
            this.Db.Items.Add(new Card(new Guid(), 1, "number"));
            this.Db.Items.Add(new Card(new Guid(), 2, "number"));
            this.Db.Items.Add(new Card(new Guid(), 3, "number"));
            this.Db.Items.Add(new Card(new Guid(), 5, "number"));
            this.Db.Items.Add(new Card(new Guid(), 8, "number"));
            this.Db.Items.Add(new Card(new Guid(), 13, "number"));
            this.Db.Items.Add(new Card(new Guid(), 20, "number"));
            this.Db.Items.Add(new Card(new Guid(), 40, "number"));
            this.Db.Items.Add(new Card(new Guid(), 100, "number"));
            this.Db.Items.Add(new Card(new Guid(), null, "question"));
            this.Db.Items.Add(new Card(new Guid(), null, "infinity"));
            this.Db.Items.Add(new Card(new Guid(), null, "coffee"));
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
