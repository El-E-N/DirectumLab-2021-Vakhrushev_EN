using System;
using DataService.Models;
using DataService.Models.Contexts;

namespace DataService.Repositories
{
    /// <summary>
    /// Репозиторий игроков.
    /// </summary>
    public class PlayerMemoryRepository : MemoryRepository<Player>
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст.</param>
        public PlayerMemoryRepository(PlayerContext context) : base(context)
        { 
        }

        /// <summary>
        /// Создание игрока.
        /// </summary>
        /// <param name="id">Id игрока.</param>
        /// <param name="name">Имя игрока.</param>
        /// <param name="token">Токен игрока.</param>
        public void Create(Guid id, string name, string token)
        {
            this.Db.Items.Add(new Player(id, name, token));
            this.Db.SaveChanges();
        }
    }
}
