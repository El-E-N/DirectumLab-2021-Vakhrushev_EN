using System;
using DataService.Models;
using DataService.Models.Contexts;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий комнат.
    /// </summary>
    public class RoomMemoryRepository : MemoryRepository<Room>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public RoomMemoryRepository(RoomContext context) : base(context) 
        { 
        }

        /// <summary>
        /// Создание комнаты.
        /// </summary>
        /// <param name="name">Название комнаты.</param>
        /// <param name="hostId">Id ведущего.</param>
        /// <param name="creatorId">Id создателя.</param>
        /// <param name="id">Id комнаты.</param>
        /// <param name="hash">Хэш комнаты.</param>
        public void Create(string name, Guid hostId, Guid creatorId, Guid id, Guid hash)
        {
            this.Db.Items.Add(new Room(name, hostId, creatorId, id, hash));
            this.Db.SaveChanges();
        }
    }
}
