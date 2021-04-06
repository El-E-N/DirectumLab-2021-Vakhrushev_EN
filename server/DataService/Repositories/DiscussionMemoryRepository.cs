using System;
using DataService.Models;
using DataService.Models.Contexts;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий обсуждений.
    /// </summary>
    public class DiscussionMemoryRepository : MemoryRepository<Discussion>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public DiscussionMemoryRepository(DiscussionContext context) : base(context) 
        {
        }

        /// <summary>
        /// Создание обсуждения.
        /// </summary>
        /// <param name="id">Id обсуждения.</param>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название обсуждения.</param>
        public void Create(Guid id, Guid roomId, string name)
        {
            this.Db.Items.Add(new Discussion(id, roomId, name));
            this.Db.SaveChanges();
        }
    }
}
