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
        private readonly PlayerMemoryRepository repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий игроков.</param>
        public PlayerService(PlayerMemoryRepository repository)
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
            this.repository.Create(id, name, token);
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
            var token = this.repository.Get(playerId).Token;
            var item = new Player(playerId, name, token);
            this.repository.Save(item);
            return this.repository.Get(playerId);
        }

        /// <summary>
        /// Вернуть токен игрока.
        /// </summary>
        /// <param name="id">Id игрока.</param>
        /// <returns>Токен.</returns>
        public string GetToken(Guid id) => this.Get(id).Token;

        /// <summary>
        /// Получение игрока.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Игрок.</returns>
        public Player Get(Guid id) => this.repository.Get(id);

        /// <summary>
        /// Получение всех игроков.
        /// </summary>
        /// <returns>Все игроки из базы данных.</returns>
        public IQueryable<Player> GetPlayers()
        {
            return this.repository.GetItems();
        }
    }
}
