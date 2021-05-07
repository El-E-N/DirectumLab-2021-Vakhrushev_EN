using DataService.Models;
using DataService.Repositories;
using System;
using System.Linq;

namespace PlanPoker.Services
{
    /// <summary>
    /// Сервис комнаты.
    /// </summary>
    public class RoomService
    {
        /// <summary>
        /// Репозиторий комнат.
        /// </summary>
        private readonly RoomMemoryRepository repository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="repository">Репозиторий комнта.</param>
        public RoomService(RoomMemoryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Создание комнаты.
        /// </summary>
        /// <param name="name">Название комнаты.</param>
        /// <param name="creatorId">Id создателя комнаты.</param>
        /// <returns>Созданная комната.</returns>
        public Room Create(string name, Guid creatorId) 
        {
            var id = Guid.NewGuid();
            var hash = Guid.NewGuid();
            this.repository.Create(name, creatorId, creatorId, id, hash);
            return this.repository.Get(id);
        }

        /// <summary>
        /// Получение комнаты по хэшу.
        /// </summary>
        /// <param name="hash">Хэш.</param>
        /// <returns>Комната.</returns>
        public Room GetByHash(Guid hash) => this.repository.GetByHash(hash);

        /// <summary>
        /// Добавление игрока в комнату.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        public void AddPlayer(Guid roomId, Guid playerId)
        {
            this.repository.Get(roomId).PlayersIds.Add(playerId);
        }

        /// <summary>
        /// Удаление игрока из комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        public void RemovePlayer(Guid roomId, Guid playerId) 
        {
            this.repository.Get(roomId).PlayersIds.Remove(playerId);
        }

        /// <summary>
        /// Изменение ведущего комнаты.
        /// </summary>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="hostId">Id ведущего.</param>
        public void ChangeHost(Guid roomId, Guid hostId)
        {
            var name = this.repository.Get(roomId).Name;
            var hash = this.repository.Get(roomId).Hash;
            var creatorId = this.repository.Get(roomId).CreatorId;
            this.repository.Save(new Room(name, hostId, creatorId, roomId, hash));
        }

        /// <summary>
        /// Получение всех комнат.
        /// </summary>
        /// <returns>Все комнаты из базы данных.</returns>
        public IQueryable<Room> GetRooms()
        {
            return this.repository.GetItems();
        }
    }
}
