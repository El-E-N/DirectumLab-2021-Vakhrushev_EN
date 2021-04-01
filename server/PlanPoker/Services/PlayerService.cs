using System;
using System.Linq;
using DataService.Models;
using DataService.Repositories;

namespace PlanPoker.Services
{
    /// <summary>
    /// Сервис игрока.
    /// </summary>
    public class PlayerService
    {
        /// <summary>
        /// Репозиторий игроков.
        /// </summary>
        public readonly IRepository<Player> repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий игроков.</param>
        public PlayerService(IRepository<Player> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Создание игрока.
        /// </summary>
        /// <param name="name">Имя игрока.</param>
        /// <returns>Объект созданного игрока.</returns>
        public Player Create(string name) 
        {
            var token = Guid.NewGuid().ToString();
            var id = Guid.NewGuid();
            this.repository.Create(new Player(id, name, token));
            this.repository.Save();
            return this.repository.Get(id);
        }

        /// <summary>
        /// Изменение имени игрока.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="name">Новое имя игрока.</param>
        /// <returns>Игрок с измененным именем.</returns>
        public Player ChangeName(Guid playerId, string name)
        {
            this.repository.Get(playerId).Name = name;
            this.repository.Save();
            return this.repository.Get(playerId);
        }

        /// <summary>
        /// Просто для проверки работы.
        /// </summary>
        /// <returns>Все игроки из базы данных.</returns>
        public IQueryable<Player> GetAll()
        {
            return this.repository.GetAll();
        }
    }
}
