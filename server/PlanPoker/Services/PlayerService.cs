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
        public readonly IRepository<Player> Repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий игроков.</param>
        public PlayerService(IRepository<Player> repository)
        {
            this.Repository = repository;
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
            this.Repository.Create(new Player(id, name, token));
            this.Repository.Save();
            return this.Repository.Get(id);
        }

        /// <summary>
        /// Изменение имени игрока.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="name">Новое имя игрока.</param>
        /// <returns>Игрок с измененным именем.</returns>
        public Player ChangeName(Guid playerId, string name)
        {
            this.Repository.Get(playerId).Name = name;
            this.Repository.Save();
            return this.Repository.Get(playerId);
        }

        /// <summary>
        /// Получение игрока.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Игрок.</returns>
        public Player Get(Guid id) => this.Repository.Get(id);

        /// <summary>
        /// Получение всех игроков.
        /// </summary>
        /// <returns>Все игроки из базы данных.</returns>
        public IQueryable<Player> GetPlayers()
        {
            return this.Repository.GetAll();
        }
    }
}
