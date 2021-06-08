using System;
using System.Linq;
using System.Collections.Generic;
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
        public void Create(string name, Guid hostId, Guid creatorId, Guid id, Guid hash, ICollection<Guid> playersIds)
        {
            this.Db.Items.Add(new Room(name, hostId, creatorId, id, hash, playersIds));
            this.Db.SaveChanges();
        }

        /// <summary>
        /// Получение комнаты по хэшу.
        /// </summary>
        /// <param name="hash">Хэш.</param>
        /// <returns>Комната.</returns>
        public Room GetByHash(Guid hash) => this.Db.Items.Where(room => room.Hash == hash).First();
    }
}
